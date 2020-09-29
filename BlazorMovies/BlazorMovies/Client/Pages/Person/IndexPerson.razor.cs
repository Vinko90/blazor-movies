using BlazorMovies.Client.Repository;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Person
{
    public partial class IndexPerson
    {
        private List<BlazorMovies.Shared.Entities.Person> PersonList;

        [Inject]
        protected PersonRepository personRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                PersonList = await personRepository.GetPersons();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task DeletePerson(int id)
        {
            await personRepository.DeletePerson(id);
            PersonList = await personRepository.GetPersons();
        }
    }
}