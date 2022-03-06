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
        private IMapper _mapper;
        private IEnderecoDao _enderecoDao;

        public EnderecoController(IEnderecoDao enderecoDao, IMapper mapper)
        {
            _enderecoDao = enderecoDao;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<ReadEnderecoDto> Get()
        {
            return _enderecoDao.Read();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadEnderecoDto enderecoDto = _enderecoDao.GetEnderecoById(id);
            if (enderecoDto == null)
                return NotFound();

            return Ok(enderecoDto);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _enderecoDao.Create(enderecoDto);
            return CreatedAtAction(nameof(GetById), new { Id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            if(!_enderecoDao.Update(id, enderecoDto))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_enderecoDao.Delete(id))
                return NotFound();

            return NoContent();
        }
    }
}
