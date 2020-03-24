using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using DotMovies.Models;

namespace DotMovies.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public static readonly HttpClient OMDB = new HttpClient();

        public DbSet<Movie> Saved { get; set; }
    }
}