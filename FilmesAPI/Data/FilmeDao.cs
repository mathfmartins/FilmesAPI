using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Dto.FilmeDto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Data
{
    public class FilmeDao : IFilmeDao
    {
        private CinemaContext _context;
        private IMapper _mapper;

        public FilmeDao(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Filme Create(CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);


            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return filme;
        }


        public bool Delete(int id)
        {
            Filme filme = GetById(id);
            if (filme == null)
                return false;
            
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return true;
        }

        public Filme GetById(int id)
        {
            return _context.Filmes.Where(filme => filme.Id == id).FirstOrDefault();

        }

        public ReadFilmeDto GetFilmeById(int id)
        {
            var filme = GetById(id);
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public IEnumerable<ReadFilmeDto> Read()
        {
            var filmes = _mapper.Map < IEnumerable<ReadFilmeDto>>(_context.Filmes);
            return filmes;
        }

        public bool Update(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = GetById(id);
            if (filme == null)
                return false;

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return true;
        }
    }
}
