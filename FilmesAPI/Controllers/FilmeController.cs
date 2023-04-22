using System.Net;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FilmesAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase 
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilmes([FromBody] Filme filme) {

        filme.id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Titulo);  
          
    }

    [HttpGet]
    public IEnumerable<Filme>  RecuperarFilmes( [FromQuery]int skip=0,[FromQuery] int take=50 ) {

        return filmes.Skip(skip).Take(take);
    }

   

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) {

       var movie = filmes.FirstOrDefault(movie => movie.id == id);

        if (movie == null) { return NotFound(); }
        return Ok(movie);
    }

}
