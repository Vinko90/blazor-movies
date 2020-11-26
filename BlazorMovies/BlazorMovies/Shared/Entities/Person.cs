using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMovies.Shared.Entities
{
    /// <summary>
    /// Person database model class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Actor Id primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Actor name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Actor biography description.
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Actor photo image reference.
        /// Return the path of the image stored in the server wwwwroot folder.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        [Required]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// List of movies who belong to this actor.
        /// </summary>
        public List<MoviesActors> ActorList { get; set; } = new List<MoviesActors>();

        /// <summary>
        /// Character name.
        /// </summary>
        [NotMapped]
        public string Character { get; set; }

        /// <summary>
        /// Compare two actor objects.
        /// </summary>
        /// <param name="obj">The actor object this actor need to be compared to.</param>
        /// <returns>True if the two object have the same primary key.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Person p2)
            {
                return Id == p2.Id;
            }

            return false;
        }

        /// <summary>
        /// Get the Hash code of this object
        /// </summary>
        /// <returns>The object hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
