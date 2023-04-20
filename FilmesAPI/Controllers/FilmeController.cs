using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdicionaFilmes([FromBody] Filme filme) {

        if (!String.IsNullOrEmpty(filme.Titulo) && (!string.IsNullOrEmpty(filme.Genero)) && (filme.Duracao>=40)){ 
        filmes.Add(filme);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Titulo);  
        }

    }


}
