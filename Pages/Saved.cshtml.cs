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
    public class SavedModel : PageModel
    {
        private readonly MoviesDbContext _context;

        public SavedModel(MoviesDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get; set; }

        public async Task OnGetAsync()
        {
            Movies = await _context.Saved.ToListAsync();
        }

        public ActionResult OnGetMovies()
        {
            return new JsonResult(_context.Saved.ToList());
        }

        public async Task<IActionResult> OnPostSaveAsync(string id)
        {
            if(id == null){
                id = "";
            }
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&i={id}&plot=full");
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);

            if(_context.Saved.Any(m => m.imdbId == id)){
                _context.Saved.Remove(movie);
            } else
            {
                movie.Saved = true;
                _context.Saved.Add(movie);
            }

            await _context.SaveChangesAsync();
            
            return new JsonResult(_context.Saved.ToList());
        }
    }
}
