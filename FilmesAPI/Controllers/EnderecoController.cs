using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dtos.EnderecoDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private CinemaContext _context;
        private IMapper _mapper;

        public EnderecoController(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private DbSet<Endereco> GetEnderecos()
        {
            return _context.Enderecos;
        }

        private Endereco GetEnderecoById(int id)
        {
            return GetEnderecos().Where(endereco => endereco.Id == id).FirstOrDefault();
        }

        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            var enderecos = _mapper.Map<IEnumerable<Endereco>>(GetEnderecos());
            return enderecos;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Endereco endereco = GetEnderecoById(id);

            if (endereco == null)
                return NotFound();
            
            endereco = _mapper.Map<Endereco>(endereco);
            return Ok(endereco);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = GetEnderecoById(id);
            if (endereco == null)
                return NotFound();

            _mapper.Map(enderecoDto, endereco);
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Endereco endereco = GetEnderecoById(id);
            if (endereco == null)
                return NotFound();

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent(); 
        }
    }
}
