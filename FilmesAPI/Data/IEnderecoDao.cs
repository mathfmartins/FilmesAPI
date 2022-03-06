using FilmesAPI.Dtos.EnderecoDto;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Data
{
    public interface IEnderecoDao
    {
        Endereco Create(CreateEnderecoDto enderecoDto);
        IEnumerable<ReadEnderecoDto> Read();
        Endereco GetById(int id);
        ReadEnderecoDto GetEnderecoById(int id);
        bool Update(int id, UpdateEnderecoDto enderecoDto);
        bool Delete(int id);
    }
}
