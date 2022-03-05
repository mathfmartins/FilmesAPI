using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
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
