using Microsoft.AspNetCore.Components;
using System;

namespace BlazorMovies.Client.Pages.Person
{
    public partial class EditPerson
    {
        [Parameter]
        public int PersonId { get; set; }

        private BlazorMovies.Shared.Entities.Person PersonItem;

        protected override void OnInitialized()
        {
            PersonItem = new BlazorMovies.Shared.Entities.Person() { Name = "Vins", DateOfBirth = DateTime.Today, Biography = "Fill Bios!" };
        }

        private void Edit()
        {
            Console.WriteLine("Edit person hit");
        }
    }
}
