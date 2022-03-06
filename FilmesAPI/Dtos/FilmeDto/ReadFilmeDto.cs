using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Dto
{
    public class ReadFilmeDto
    {
        public ReadFilmeDto()
        {
            this.HoraDaConsulta = DateTime.Now;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public string Genero { get; set; }

        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
