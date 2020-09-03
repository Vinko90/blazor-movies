using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class GenreForm
    {
        [Parameter]
        public Genre GenreItem { get; set; }

        [Parameter]
        public EventCallback OnValidGenreSubmit { get; set; }
    }
}
