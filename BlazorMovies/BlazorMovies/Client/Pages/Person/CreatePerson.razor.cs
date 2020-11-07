using BlazorMovies.Client.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Person
{
    [Authorize]
    public partial class CreatePerson
    {
        private BlazorMovies.Shared.Entities.Person personItem = new BlazorMovies.Shared.Entities.Person();

        [Inject]
        protected PersonRepository personRepository { get; set; }

        [Inject]
        protected NavigationManager navMan { get; set; }

        private async Task Create()
        {
            try
            {
                await personRepository.CreatePerson(personItem);
                navMan.NavigateTo("person");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
