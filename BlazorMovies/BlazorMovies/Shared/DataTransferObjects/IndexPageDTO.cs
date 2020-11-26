using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// IndexPageDTO class implementation.
    /// Used in homepage to show list of movies who are currently played in theaters and upcoming releases.
    /// </summary>
    public class IndexPageDTO
    {
        /// <summary>
        /// List of in theaters movies.
        /// </summary>
        public List<Movie> InTheathers { get; set; }

        /// <summary>
        /// List of upcoming releases movies.
        /// </summary>
        public List<Movie> UpcomingReleases { get; set; }
    }
}