using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// MovieUpdateDTO class implementation.
    /// </summary>
    public class MovieUpdateDTO
    {
        /// <summary>
        /// Movie Object
        /// </summary>
        public Movie MovieItem { get; set; }

        /// <summary>
        /// List of actors
        /// </summary>
        public List<Person> Actors { get; set; }

        /// <summary>
        /// List of genres who are selected for this movie
        /// </summary>
        public List<Genre> SelectedGenres { get; set; }

        /// <summary>
        /// List of genres who are not currently selected for this movie
        /// </summary>
        public List<Genre> NotSelectedGenres { get; set; }
    }
}
