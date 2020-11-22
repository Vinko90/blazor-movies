using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Components.Shared
{
    public partial class PersonForm
    {
        [Parameter]
        public Person PersonItem { get; set; }
        
        [Parameter]
        public EventCallback OnValidPersonSubmit { get; set; }

        private string ImageURL;

        protected override void OnInitialized()
        {
            if (!string.IsNullOrEmpty(PersonItem.Picture))
            {
                ImageURL = PersonItem.Picture;
                PersonItem.Picture = null;
            }
        }

        private void PictureSelected(string imageBase64)
        {
            PersonItem.Picture = imageBase64;
            ImageURL = null;
        }
    }
}
