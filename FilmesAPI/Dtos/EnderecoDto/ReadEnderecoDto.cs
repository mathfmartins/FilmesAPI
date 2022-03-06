using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
    }
}
