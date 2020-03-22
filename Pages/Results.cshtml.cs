using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DotMovies.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly ILogger<ResultsModel> _logger;

        public ResultsModel(ILogger<ResultsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
