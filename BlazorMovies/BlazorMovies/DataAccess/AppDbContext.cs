using BlazorMovies.Shared.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorMovies.DataAccess
{
    /// <summary>
    /// AppDbContext class implementation.
    /// An instance of this class hold references to all the database tables of the current application.
    /// </summary>
    public class AppDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="options">Database context options</param>
        /// <param name="operationalStoreOptions">IdentityServer4 store options</param>
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }

        /// <summary>
        /// Method called when model is created
        /// </summary>
        /// <param name="modelBuilder">The model builder object</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Genre record table.
        /// </summary>
        public DbSet<Genre> GenresRecords { get; set; }

        /// <summary>
        /// Movie record table.
        /// </summary>
        public DbSet<Movie> MoviesRecords { get; set; }

        /// <summary>
        /// Person record table.
        /// </summary>
        public DbSet<Person> PersonRecords { get; set; }

        /// <summary>
        /// MoviesActors record table.
        /// </summary>
        public DbSet<MoviesActors> MoviesActorsRecords { get; set; }

        /// <summary>
        /// MoviesGenres record table.
        /// </summary>
        public DbSet<MoviesGenres> MoviesGenresRecords { get; set; }

        /// <summary>
        /// MovieRating record table.
        /// </summary>
        public DbSet<MovieRating> MovieRatings { get; set; }
    }
}
