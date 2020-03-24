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

        public async Task<Movie> Get(string id)
        {
            var movie = await _context.Saved.FindAsync(id);
            return movie;
        }

        public async Task<List<Movie>> GetByTitle(string title){

            if(title == null){
                title = "";
            }

            //Dummy data from OMDB
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&s={title}");
            OMDBResponse omdb = JsonConvert.DeserializeObject<OMDBResponse>(json);

            List<Movie> savedMovies = await _context.Saved.ToListAsync();

            foreach (Movie movie in omdb.Search)
            {
                if(savedMovies.Any(m => m.imdbId == movie.imdbId)){
                    movie.Saved = true;
                }
            }

            return omdb.Search;
        }

        public async Task<Movie> Add(Movie movie)
        {
            _context.Saved.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
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