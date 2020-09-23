using BlazorMovies.Server.DataContext;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public GenresController(AppDbContext context)
        {
            dbcontext = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genre genre)
        {
            dbcontext.Add(genre);
            await dbcontext.SaveChangesAsync();
            return genre.Id;
        }
    }
}
