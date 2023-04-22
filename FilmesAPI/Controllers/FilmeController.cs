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
    public IActionResult AdicionaFilmes([FromBody] Filme filme) {

        filme.id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmeId), new {
            id= filme.id}, filme);
               
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
