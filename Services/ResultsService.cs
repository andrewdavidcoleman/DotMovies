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

        public async Task<List<Movie>> Search(string title){

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
    }
}