using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DotMovies.Data;
using DotMovies.Models;

namespace DotMovies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MoviesDbContext _context;

        public IndexModel(MoviesDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
