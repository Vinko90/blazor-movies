using BlazorMovies.Server.DataContext;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext dbcontext;
        private readonly IFileStorageService fileStorageService;

        public PeopleController(AppDbContext context, IFileStorageService fileStorageService)
        {
            dbcontext = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return await dbcontext.PersonRecords.ToListAsync();
        }

        public async Task<ActionResult<int>> Post(Person person)
        {
            if (!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorageService.SaveFile(personPicture, "jpg", "img_people");
            }

            dbcontext.Add(person);
            await dbcontext.SaveChangesAsync();
            return person.Id;
        }
    }
}
