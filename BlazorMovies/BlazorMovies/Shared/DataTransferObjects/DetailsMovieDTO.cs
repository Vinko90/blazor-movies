using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// DetailsMovieDTO class implementation. Used to post movie details info to the page..
    /// </summary>
    public class DetailsMovieDTO
    {
        /// <summary>
        /// The movie object
        /// </summary>
        public Movie MovieItem { get; set; }

        /// <summary>
        /// The list of genres this movie is part of.
        /// </summary>
        public List<Genre> Genres { get; set; }

        /// <summary>
        /// The list of actors partecipating in the movie
        /// </summary>
        public List<Person> Actors { get; set; }

        /// <summary>
        /// Average movie rating vote
        /// </summary>
        public double AverageVote { get; set; }

        /// <summary>
        /// Logged user rating vote
        /// </summary>
        public int UserVote { get; set; }
    }
}
