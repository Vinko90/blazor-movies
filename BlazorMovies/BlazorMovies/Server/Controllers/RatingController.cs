using BlazorMovies.Server.DataContext;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatingController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RatingController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            dbContext = context;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Rate(MovieRating movieRating)
        {
            var user = await userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            var userId = user.Id;

            var currentRating = await dbContext.MovieRatings
                .FirstOrDefaultAsync(x => x.MovieId == movieRating.MovieId && x.UserId == userId);

            if (currentRating == null)
            {
                movieRating.UserId = userId;
                movieRating.RatingDate = DateTime.Today;
                dbContext.Add(movieRating);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                currentRating.Rate = movieRating.Rate;
                await dbContext.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
