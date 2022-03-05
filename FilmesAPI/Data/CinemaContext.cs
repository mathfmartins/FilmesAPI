using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class CinemaContext : DbContext
    {
  
        public CinemaContext(DbContextOptions<CinemaContext> opts) : base(opts)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
