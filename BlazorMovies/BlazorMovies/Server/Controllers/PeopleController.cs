using AutoMapper;
using BlazorMovies.Server.DataContext;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class PeopleController : ControllerBase
    {
        private readonly string PersonImageContainerName = "img_people";
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
        [AllowAnonymous]
        public async Task<ActionResult<List<Person>>> Get([FromQuery]PaginationDTO paginationSettings)
        {
            var queryable = dbcontext.PersonRecords.AsQueryable();
            await HttpContext.InsertPaginationParametersInReponse(queryable, paginationSettings.RecordsPerPage);
            return await queryable.Paginate(paginationSettings).ToListAsync();
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
        [AllowAnonymous]
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
                person.Picture = await fileStorageService.SaveFile(personPicture, "jpg", PersonImageContainerName);
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
                personDB.Picture = await fileStorageService.EditFile(personPicture, "jpg", PersonImageContainerName, personDB.Picture);
            }

            await dbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await dbcontext.PersonRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null) { return NotFound(); }

            dbcontext.Remove(person);
            await dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
