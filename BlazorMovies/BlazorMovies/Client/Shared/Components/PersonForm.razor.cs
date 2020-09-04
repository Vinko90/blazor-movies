using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class PersonForm
    {
        [Parameter]
        public Person PersonItem { get; set; }
        
        [Parameter]
        public EventCallback OnValidPersonSubmit { get; set; }

        private string ImageURL;

        private void PictureSelected(string imageBase64)
        {
            PersonItem.Picture = imageBase64;
            ImageURL = null;
        }

        protected override void OnInitialized()
        {
            if (!string.IsNullOrEmpty(PersonItem.Picture))
            {
                ImageURL = PersonItem.Picture;
                PersonItem.Picture = null;
            }
        }
    }
}
