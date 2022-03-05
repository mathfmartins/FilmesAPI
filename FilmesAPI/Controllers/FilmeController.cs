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
       
        private CinemaContext _context;
        private IMapper _mapper;

        public FilmeController(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFirme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        [HttpGet]   
        public IActionResult GetFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            Filme filme = _context.Filmes.Where((filme) => filme.Id == id).FirstOrDefault();
            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }

            return NotFound();
        }   

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody]  UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.Where((filme) => filme.Id == id).FirstOrDefault();
            if (filme != null)
            {
                _mapper.Map(filmeDto, filme); 
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Filme filme = _context.Filmes.Where((filme) => filme.Id == id).FirstOrDefault();
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
