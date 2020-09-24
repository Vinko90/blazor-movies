using BlazorMovies.Server.DataContext;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await dbcontext.GenresRecords.ToListAsync();
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