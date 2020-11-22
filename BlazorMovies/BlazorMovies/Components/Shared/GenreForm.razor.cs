using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Components.Shared
{
    public partial class GenreForm
    {
        [Parameter]
        public Genre GenreItem { get; set; }

        [Parameter]
        public EventCallback OnValidGenreSubmit { get; set; }
    }
}
