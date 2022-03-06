using FilmesAPI.Dto;
using FilmesAPI.Dto.FilmeDto;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Data
{
    public interface IFilmeDao
    {
        Filme Create(CreateFilmeDto filme);
        IEnumerable<ReadFilmeDto> Read();
        Filme GetById(int id);
        ReadFilmeDto GetFilmeById(int id);
        bool Update(int id, UpdateFilmeDto filme);
        bool Delete(int id);

    }
}
