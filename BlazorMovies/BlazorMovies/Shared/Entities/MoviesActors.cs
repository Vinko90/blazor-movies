namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// MoviesActors database model class.
    /// </summary>
    public class MoviesActors
    {
        /// <summary>
        /// Actor Id primary key.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Movie Id primary key.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Person object reference.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Movie object reference.
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// The actor character name.
        /// </summary>
        public string CharacterName { get; set; }

        /// <summary>
        /// The order priority number for list sortering.
        /// </summary>
        public int Order { get; set; }
    }
}
