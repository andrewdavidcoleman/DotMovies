using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
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
    public class ResultsModel : PageModel
    {
        private readonly ResultsService _service;

        public ResultsModel(ResultsService service)
        {
            _service = service;
        }

        public IList<Movie> Movies { get; set; } = new List<Movie>();

        public async Task OnGetAsync(string title)
        {
            Movies = await _service.GetByTitle(title);
        }
    }
}
