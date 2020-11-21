using BlazorMovies.Shared.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorMovies.Server.DataContext
{
    public class AppDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genre> GenresRecords { get; set; }
        public DbSet<Movie> MoviesRecords { get; set; }
        public DbSet<Person> PersonRecords { get; set; }
        public DbSet<MoviesActors> MoviesActorsRecords { get; set; }
        public DbSet<MoviesGenres> MoviesGenresRecords { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
    }
}
