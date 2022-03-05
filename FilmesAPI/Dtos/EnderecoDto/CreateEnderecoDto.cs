using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.EnderecoDto
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public int Numero { get; set; }
    }
}
