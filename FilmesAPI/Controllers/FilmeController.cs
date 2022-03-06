using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Dto.FilmeDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
       
        private IFilmeDao _filmeDao;
        private IMapper _mapper;

        public FilmeController(IFilmeDao context, IMapper mapper)
        {
            _filmeDao = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFirme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _filmeDao.Create(filmeDto);
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        [HttpGet]   
        public IActionResult GetFilmes()
        {
            return Ok(_filmeDao.Read());
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            ReadFilmeDto filmeDto = _filmeDao.GetFilmeById(id);
            if (filmeDto == null)
                return NotFound();

            return Ok(filmeDto);
        }   

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody]  UpdateFilmeDto filmeDto)
        {
            if (!_filmeDao.Update(id, filmeDto))
                return NotFound();

            _filmeDao.Update(id, filmeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            if(!_filmeDao.Delete(id))
                return NotFound();
          
            return NoContent();
        }
    }
}
