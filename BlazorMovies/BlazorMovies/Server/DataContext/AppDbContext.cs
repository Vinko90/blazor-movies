using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovies.Server.DataContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
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
