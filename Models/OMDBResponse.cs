using System.Collections.Generic;

namespace DotMovies.Models
{
    public class OMDBResponse
    {
        public List<Movie> Search { get; set; } = new List<Movie>();
        public int totalResults { get; set; }
        public bool Response { get; set; }
    }
}