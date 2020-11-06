using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Person
{
    public partial class IndexPerson
    {
        private List<BlazorMovies.Shared.Entities.Person> PersonList;
        private PaginationDTO pagination = new PaginationDTO();


        [Inject]
        protected PersonRepository personRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var paginatedResponse = await personRepository.GetPersons(pagination);
                PersonList = paginatedResponse.Response;
                Console.WriteLine(paginatedResponse.TotalAmountOfPages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task DeletePerson(int id)
        {
            await personRepository.DeletePerson(id);
            var paginatedResponse = await personRepository.GetPersons(pagination);
            PersonList = paginatedResponse.Response;
            Console.WriteLine(paginatedResponse.TotalAmountOfPages);
        }
    }
}