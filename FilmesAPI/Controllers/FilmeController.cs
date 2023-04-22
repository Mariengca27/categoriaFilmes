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
    public IEnumerable<Filme>  RecuperarFilmes() {

        return filmes.Skip(2).Take(3);
    }


    [HttpGet("{id}")]
    public Filme? RecuperaFilmeId(int id) {

        return filmes.FirstOrDefault(filme => filme.id == id);
    
    }



}
