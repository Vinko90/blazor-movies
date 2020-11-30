using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tewr.Blazor.FileReader;

namespace BlazorMovies.Components.Shared
{
    public partial class InputImg
    {
        private string imageBase64;
        private readonly ElementReference inputReference;

        private async Task ImageFileSelected()
        {
            foreach (var file in await FileReaderService.CreateReference(inputReference).EnumerateFilesAsync())
            {
                using MemoryStream memoryStream = await file.CreateMemoryStreamAsync(4 * 1024);
                var imageBytes = new byte[memoryStream.Length];
                memoryStream.Read(imageBytes, 0, (int)memoryStream.Length);
                imageBase64 = Convert.ToBase64String(imageBytes);
                await OnSelectedImage.InvokeAsync(imageBase64);
                ImageURL = null;
                StateHasChanged();
            }
        }

        [Inject]
        private IFileReaderService FileReaderService { get; set; }

        [Parameter]
        public string Label { get; set; } = "Image";

        [Parameter]
        public string ImageURL { get; set; }

        [Parameter]
        public EventCallback<string> OnSelectedImage { get; set; }
    }
}