using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Person
{
    [Authorize(Roles = "Admin")]
    public partial class EditPerson
    {
        [Inject]
        public IPersonRepository personRepository { get; set; }

        [Inject]
        public NavigationManager navMan { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private BlazorMovies.Shared.Entities.Person PersonItem;

        protected async override Task OnInitializedAsync()
        {
            PersonItem = await personRepository.GetPersonById(PersonId);
        }

        private async Task Edit()
        {
            await personRepository.UpdatePerson(PersonItem);
            navMan.NavigateTo("person");
        }
    }
}
