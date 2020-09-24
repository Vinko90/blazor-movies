using BlazorMovies.Server.DataContext;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public PeopleController(AppDbContext context)
        {
            dbcontext = context;
        }

        public async Task<ActionResult<int>> Post(Person person)
        {
            dbcontext.Add(person);
            await dbcontext.SaveChangesAsync();
            return person.Id;
        }
    }
}
