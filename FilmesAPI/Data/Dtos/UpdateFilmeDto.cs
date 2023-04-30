using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateFilmeDto
{
  
    [Required(ErrorMessage = "Colocar o Título")]
    [StringLength(30, ErrorMessage = "O nome do filmes deve conter no máximo 30 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Colocar o Gênero do Filme")]
    [StringLength(50, ErrorMessage = "O TAMANHO NÃO PODE SER MAIOR QUE 50 CARACTERES.")]
    public string Genero { get; set; }


    [Required(ErrorMessage = "Colocar a duração do filme")]
    [Range(70, 500, ErrorMessage = "A duração deve estar em 70 minutos e 500 minutos.")]
    public int Duracao { get; set; }


}
