using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
        Task DeletePerson(int id);
        Task<List<Person>> GetPeopleByName(string name);
        Task<Person> GetPersonById(int id);
        Task<PaginatedResponse<List<Person>>> GetPersons(PaginationDTO paginationSettings);
        Task UpdatePerson(Person person);
    }
}