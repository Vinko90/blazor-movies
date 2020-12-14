using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorMovies.Components.Shared
{
    public partial class InputImg
    {
        private string imageBase64;

        private async Task ImageFileSelected(InputFileChangeEventArgs e)
        {
            var imagesFiles = e.GetMultipleFiles();

            foreach (var imageFile in imagesFiles)
            {
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream().ReadAsync(buffer);
                imageBase64 = Convert.ToBase64String(buffer);

                await OnSelectedImage.InvokeAsync(imageBase64);
                ImageURL = null;
                StateHasChanged();              
            }
        }

        [Parameter]
        public string Label { get; set; } = "Image";

        [Parameter]
        public string ImageURL { get; set; }

        [Parameter]
        public EventCallback<string> OnSelectedImage { get; set; }
    }
}