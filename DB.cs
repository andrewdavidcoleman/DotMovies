using Microsoft.EntityFrameworkCore;
using DotMovies.Models;

namespace DotMovies.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}