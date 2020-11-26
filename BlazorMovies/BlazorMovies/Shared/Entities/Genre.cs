using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// Genre database model class.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Genre Id primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Genre name string.
        /// </summary>
        [Required(ErrorMessage = "Genre name is required")]
        public string Name { get; set; }

        /// <summary>
        /// List of movies having this genre.
        /// </summary>
        public List<MoviesGenres> MovieList { get; set; } = new List<MoviesGenres>();
    }
}
