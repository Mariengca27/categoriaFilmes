using System.Net;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FilmesAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase 
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilmes([FromBody] CreateFilmeDto filmeDto) {

        Filme filme = _mapper.Map<Filme>(filmeDto); 


        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmeId), new {
            id= filme.id}, filme);
               
    }

    [HttpGet]
    public IEnumerable<Filme>  RecuperarFilmes( [FromQuery]int skip=0,[FromQuery] int take=50 ) {
 
        return _context.Filmes.Skip(skip).Take(take);
    }

   

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) {

       var movie = _context.Filmes.FirstOrDefault(movie => movie.id == id);

        if (movie == null) { return NotFound(); }
        return Ok(movie);
    }

}
