using System.ComponentModel.DataAnnotations;

namespace DotMovies.Models
{
    public class Movie
    {
        [Key]
        public string imdbId { get; set; }

        public string Title { get; set; }

    }
}