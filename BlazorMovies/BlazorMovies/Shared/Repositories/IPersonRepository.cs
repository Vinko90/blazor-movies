using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// IPersonRepository repository pattern interface
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Create a new person in the database.
        /// </summary>
        /// <param name="person">Person object to be created</param>
        /// <returns>This Task success status</returns>
        Task CreatePerson(Person person);

        /// <summary>
        /// Delete a person from the database.
        /// </summary>
        /// <param name="id">Person Id primary key</param>
        /// <returns>This Task success status</returns>
        Task DeletePerson(int id);

        /// <summary>
        /// Get people by first name.
        /// </summary>
        /// <param name="name">Frist name</param>
        /// <returns>List a people where name is equal of contain the input name</returns>
        Task<List<Person>> GetPeopleByName(string name);

        /// <summary>
        /// Get a person item from the database from a given primary key.
        /// </summary>
        /// <param name="id">Person id primary key</param>
        /// <returns>The peson object if found, otherwhise null</returns>
        Task<Person> GetPersonById(int id);

        /// <summary>
        /// Get a paginated list of all persons from database.
        /// </summary>
        /// <param name="paginationSettings">Pagination settings</param>
        /// <returns>All persons records paginated</returns>
        Task<PaginatedResponse<List<Person>>> GetPersons(PaginationDTO paginationSettings);

        /// <summary>
        /// Update a person in the database
        /// </summary>
        /// <param name="person">The person object to be updated</param>
        /// <returns>This Task success status</returns>
        Task UpdatePerson(Person person);
    }
}