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

namespace DotMovies.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly MoviesDbContext _context;

        public ResultsModel(MoviesDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get; set; }

        public async Task OnGetAsync(string title)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(title);
            Console.WriteLine("=================================");
            Movies = await _context.Movies.ToListAsync();
        }
    }
}
