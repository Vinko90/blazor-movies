using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// Movie database model class.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Movie Id primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie title primary key.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Movie release date.
        /// </summary>
        [Required]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Movie poster image path.
        /// Return the path of the image stored in the server wwwroot folder.
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        /// Movie summary description.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Set true if the movie is currently played in theaters.
        /// </summary>
        public bool InTheaters { get; set; }

        /// <summary>
        /// Movie trailer string link.
        /// Currently supporting trailers from embed Youtube links.
        /// </summary>
        public string Trailer { get; set; }

        /// <summary>
        /// List of genres binded to this movie item.
        /// </summary>
        public List<MoviesGenres> GenresList { get; set; } = new List<MoviesGenres>();

        /// <summary>
        /// List of actors binded to this movie item.
        /// </summary>
        public List<MoviesActors> ActorList { get; set; } = new List<MoviesActors>();

        /// <summary>
        /// Short title representation.
        /// </summary>
        public string TitleBrief
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}