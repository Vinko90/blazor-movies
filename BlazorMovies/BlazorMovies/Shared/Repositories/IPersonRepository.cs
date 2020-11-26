using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task CreatePerson(Person person);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePerson(int id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<List<Person>> GetPeopleByName(string name);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Person> GetPersonById(int id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paginationSettings"></param>
        /// <returns></returns>
        Task<PaginatedResponse<List<Person>>> GetPersons(PaginationDTO paginationSettings);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task UpdatePerson(Person person);
    }
}