using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Person
{
    [Authorize(Roles = "Admin")]
    public partial class EditPerson
    {
        private BlazorMovies.Shared.Entities.Person personItem;

        protected async override Task OnInitializedAsync()
        {
            personItem = await PersonRepository.GetPersonById(PersonId);
        }

        private async Task Edit()
        {
            await PersonRepository.UpdatePerson(personItem);
            NavMan.NavigateTo("person");
        }

        [Inject]
        public IPersonRepository PersonRepository { get; set; }

        [Inject]
        public NavigationManager NavMan { get; set; }

        [Parameter]
        public int PersonId { get; set; }
    }
}
