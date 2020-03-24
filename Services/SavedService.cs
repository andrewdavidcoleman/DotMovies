using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using DotMovies.Data;
using DotMovies.Models;

namespace DotMovies.Services
{
    public class SavedService
    {
        private readonly MoviesDbContext _context;

        public SavedService(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> Get()
        {
            return await _context.Saved.ToListAsync();
        }

        public async Task<Movie> Add(Movie movie)
        {
            _context.Saved.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> Delete(string id)
        {
            var movie = await _context.Saved.FindAsync(id);
            _context.Saved.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}