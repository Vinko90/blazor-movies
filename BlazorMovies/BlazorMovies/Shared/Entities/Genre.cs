using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        public string Name { get; set; }

        public List<MoviesGenres> MovieList { get; set; } = new List<MoviesGenres>();
    }
}
