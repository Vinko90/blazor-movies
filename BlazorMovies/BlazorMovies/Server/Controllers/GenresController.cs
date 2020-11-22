using BlazorMovies.DataAccess;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public GenresController(AppDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await dbcontext.GenresRecords.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            var genre = await dbcontext.GenresRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
                return NotFound();

            return genre;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genre genre)
        {
            dbcontext.Add(genre);
            await dbcontext.SaveChangesAsync();
            return genre.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genre genre)
        {
            dbcontext.Attach(genre).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await dbcontext.GenresRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null) { return NotFound(); }

            dbcontext.Remove(genre);
            await dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}