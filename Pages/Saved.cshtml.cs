using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DotMovies.Pages
{
    public class SavedModel : PageModel
    {
        private readonly ILogger<SavedModel> _logger;

        public SavedModel(ILogger<SavedModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
