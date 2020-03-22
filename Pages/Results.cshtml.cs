using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DotMovies.Data;
using DotMovies.Models;
using Newtonsoft.Json;

namespace DotMovies.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly MoviesDbContext _context;

        public ResultsModel(MoviesDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get; set; } = new List<Movie>();

        public async Task OnGetAsync(string title)
        {
            if(title == null){
                title = "godfather";
            }
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&s={title}");
            OMDBResponse omdb = JsonConvert.DeserializeObject<OMDBResponse>(json);

            foreach (Movie movie in omdb.Search)
            {
                Movies.Add(movie);
            }
        }
    }
}
