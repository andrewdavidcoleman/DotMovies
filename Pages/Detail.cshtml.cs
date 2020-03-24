using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DotMovies.Data;
using DotMovies.Models;
using Newtonsoft.Json;

namespace DotMovies.Pages
{
    public class DetailModel : PageModel
    {
        private readonly MoviesDbContext _context;

        public DetailModel(MoviesDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = new Movie();

        public async Task OnGetAsync(string id)
        {
            if(id == null){
                id = "";
            }

            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&i={id}&plot=full");
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);
            if(_context.Saved.Any(m => m.imdbId == id)){
                movie.Saved = true;
            }

            Movie = movie;
        }
    }
}
