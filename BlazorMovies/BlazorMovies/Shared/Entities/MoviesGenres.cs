namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// MoviesGenres database model class.
    /// </summary>
    public class MoviesGenres
    {
        /// <summary>
        /// Movie Id primary key.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Genre Id primary key.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Movie object.
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// Genre object.
        /// </summary>
        public Genre Genre { get; set; }
    }
}