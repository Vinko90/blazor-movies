using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tewr.Blazor.FileReader;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class InputImg
    {
        [Inject]
        private IFileReaderService FileReaderService { get; set; }

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
            foreach (var file in await FileReaderService.CreateReference(InputReference).EnumerateFilesAsync())
            {
                using MemoryStream memoryStream = await file.CreateMemoryStreamAsync(4 * 1024);
                var imageBytes = new byte[memoryStream.Length];
                memoryStream.Read(imageBytes, 0, (int)memoryStream.Length);
                ImageBase64 = Convert.ToBase64String(imageBytes);
                await OnSelectedImage.InvokeAsync(ImageBase64);
                ImageURL = null;
                StateHasChanged();
            }
        }
    }
}