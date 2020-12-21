using BlazorMovies.Shared.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

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

            //Add Admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin",
            });

            //Add Admin user
            var userAdminId = "6af3decf-7e66-40ea-9c87-67a88a89f368";
            var hasher = new PasswordHasher<IdentityUser>();

            var userAdmin = new IdentityUser()
            {
                Id = userAdminId,
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin_123")
            };
            modelBuilder.Entity<IdentityUser>().HasData(userAdmin);

            //Bind user to Admin role
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>()
                {
                    Id = 1,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Admin",
                    UserId = userAdminId
                });

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
