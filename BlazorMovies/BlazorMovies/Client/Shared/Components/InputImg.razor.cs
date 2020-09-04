using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class InputImg
    {
        [Parameter]
        public string Label { get; set; } = "Image";

        [Parameter]
        public string ImageURL { get; set; }

        [Parameter]
        public EventCallback<string> OnSelectedImage { get; set; }

        private string ImageBase64;

        private ElementReference InputReference;

        private async Task ImageFileSelected()
        {
            
        }
    }
}