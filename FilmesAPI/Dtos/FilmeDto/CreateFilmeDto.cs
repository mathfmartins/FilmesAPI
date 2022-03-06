using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Dto.FilmeDto
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "Título deve ser informado")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Diretor deve ser informado")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Genêro não pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600)]
        public int Duracao { get; set; }

    }
}
