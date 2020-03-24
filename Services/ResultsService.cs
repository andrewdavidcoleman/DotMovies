using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using DotMovies.Data;
using DotMovies.Models;

namespace DotMovies.Services
{
    public class ResultsService
    {
        private readonly MoviesDbContext _context;

        public ResultsService(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> Get()
        {
            return await _context.Results.ToListAsync();
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
            await _context.SaveChangesAsync();

            return omdb.Search;
        }

        public async Task<Movie> Get(string id)
        {
            //Dummy data from OMDB
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&i={id}&plot=full");
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);

            List<Movie> savedMovies = await _context.Saved.ToListAsync();
            if(savedMovies.Any(m => m.imdbId == movie.imdbId)){
                movie.Saved = true;
            }

            return movie;
        }

        public async Task<Movie> Add(Movie movie)
        {
            _context.Results.Add(movie);
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
            var movie = await _context.Results.FindAsync(id);
            _context.Results.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}