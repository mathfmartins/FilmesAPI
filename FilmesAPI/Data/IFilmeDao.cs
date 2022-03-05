using FilmesAPI.Dto;
using FilmesAPI.Dto.FilmeDto;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Data
{
    public interface IFilmeDao
    {
        Filme Create(CreateFilmeDto filme);
        IEnumerable<Filme> Read();
        Filme GetById(int id);
        ReadFilmeDto GetFilmeById(int id);
        void Update(int id, UpdateFilmeDto filme);
        bool Delete(int id);

    }
}
