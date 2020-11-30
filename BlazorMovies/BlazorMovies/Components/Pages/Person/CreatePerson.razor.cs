using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Person
{
    [Authorize(Roles = "Admin")]
    public partial class CreatePerson
    {
        private readonly BlazorMovies.Shared.Entities.Person personItem = new BlazorMovies.Shared.Entities.Person();

        private async Task Create()
        {
            try
            {
                await PersonRepository.CreatePerson(personItem);
                NavMan.NavigateTo("person");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        [Inject]
        protected IPersonRepository PersonRepository { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }
    }
}
