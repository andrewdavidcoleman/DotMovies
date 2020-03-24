using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotMovies.Data;
using DotMovies.Models;
using DotMovies.Services;

namespace DotMovies.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ResultsService _service;

        public DetailModel(ResultsService service)
        {
            _service = service;
        }

        public Movie Movie { get; set; } = new Movie();

        public async Task OnGetAsync(string id)
        {
            Movie = await _service.Get(id);
        }
    }
}
