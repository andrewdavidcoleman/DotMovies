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
    }
}
