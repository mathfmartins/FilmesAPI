using AutoMapper;
using FilmesAPI.Dtos.EnderecoDto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Data
{
    public class EnderecoDao : IEnderecoDao
    {
        private IMapper _mapper;
        private CinemaContext _context;
        public EnderecoDao(IMapper mapper, CinemaContext context)
        {
            _mapper = mapper;
            _context = context; 
        }

        public Endereco Create(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            return endereco;
        }

        public bool Delete(int id)
        {
            Endereco endereco = GetById(id);
            if (endereco == null)
                return false;
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return true;
        }

        public Endereco GetById(int id)
        {
            return _context.Enderecos.Where(endecero => endecero.Id == id).FirstOrDefault();
        }

        public ReadEnderecoDto GetEnderecoById(int id)
        {
            Endereco endereco = GetById(id);
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public IEnumerable<ReadEnderecoDto> Read()
        {
            var enderecos = _mapper.Map<IEnumerable<ReadEnderecoDto>>(_context.Enderecos);
            return enderecos;
        }

        public bool Update(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = GetById(id);
            if (endereco == null)
                return false;

            _mapper.Map(enderecoDto, endereco);
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
            return true;
        }

       
    }
}
