using System;

namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// MovieRating database model class.
    /// </summary>
    public class MovieRating
    {
        /// <summary>
        /// Rating Id primary key.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Rate value.
        /// </summary>
        public int Rate { get; set; }
        
        /// <summary>
        /// Rating date timestamp.
        /// </summary>
        public DateTime RatingDate { get; set; }
        
        /// <summary>
        /// Movie Id whom this rating belong to.
        /// </summary>
        public int MovieId { get; set; }
        
        /// <summary>
        /// The rated movie object.
        /// </summary>
        public Movie Movie { get; set; }
        
        /// <summary>
        /// The user Id whom this rating belong to.
        /// </summary>
        public string UserId { get; set; }
    }
}
