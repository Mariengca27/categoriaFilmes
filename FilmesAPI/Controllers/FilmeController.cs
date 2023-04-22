using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class FilmeController
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
    public Filme? RecuperaFilmeId(int id) {

        return filmes.FirstOrDefault(filme => filme.id == id);
    
    }



}
