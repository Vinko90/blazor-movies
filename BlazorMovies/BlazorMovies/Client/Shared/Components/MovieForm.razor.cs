using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class MovieForm
    {
        [Parameter]
        public Movie MovieItem { get; set; }

        [Parameter]
        public EventCallback OnValidMovieSubmit { get; set; }

        [Parameter]
        public List<Genre> SelectedGenres { get; set; } = new List<Genre>();

        [Parameter]
        public List<Genre> NotSelectedGenres { get; set; } = new List<Genre>();

        private string ImageURL;

        private List<MultipleSelectorModel> Selected = new List<MultipleSelectorModel>();


        private List<MultipleSelectorModel> NotSelected = new List<MultipleSelectorModel>();

        protected override void OnInitialized()
        {
            MapSelectedGenres();

            if (!string.IsNullOrEmpty(MovieItem.Poster))
            {
                ImageURL = MovieItem.Poster;
                MovieItem.Poster = null;
            }
        }

        private void PosterSelected(string imageBase64)
        {
            MovieItem.Poster = imageBase64;
            ImageURL = null;
        }

        private void MapSelectedGenres()
        {
            Selected = SelectedGenres.Select(x => new MultipleSelectorModel(x.Id.ToString(), x.Name)).ToList();
            NotSelected = NotSelectedGenres.Select(x => new MultipleSelectorModel(x.Id.ToString(), x.Name)).ToList();
        }
    }
}