using AutoMapper;
using BlazorMovies.Server.DataContext;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext dbcontext;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;

        public PeopleController(AppDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            dbcontext = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return await dbcontext.PersonRecords.ToListAsync();
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return new List<Person>();
            }

            return await dbcontext.PersonRecords.Where(x => x.Name.Contains(searchText)).Take(5).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await dbcontext.PersonRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null) { return NotFound(); }

            return person;
        }

        [HttpPost]
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

        [HttpPut]
        public async Task<ActionResult> Put(Person person)
        {
            var personDB = await dbcontext.PersonRecords.FirstOrDefaultAsync(x => x.Id == person.Id);

            if (personDB == null) { return NotFound(); }

            personDB = mapper.Map(person, personDB);

            if (!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                personDB.Picture = await fileStorageService.EditFile(personPicture, "jpg", "people", personDB.Picture);
            }

            await dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
