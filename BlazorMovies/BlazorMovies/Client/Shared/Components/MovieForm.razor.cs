using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [Parameter]
        public List<Person> SelectedActors { get; set; } = new List<Person>();

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

        private async Task<IEnumerable<Person>> SearchMethod(string searchText)
        {
            return new List<Person>() { 
                new Person() { Id = 1, Name = "Tom Holland", Picture = "https://m.media-amazon.com/images/M/MV5BNTAzMzA3NjQwOF5BMl5BanBnXkFtZTgwMDUzODQ5MTI@._V1_UY317_CR23,0,214,317_AL_.jpg"},
                new Person() { Id = 2, Name = "Tom Hanks", Picture = "https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_UY317_CR2,0,214,317_AL_.jpg"}
            };
        }

        private async Task OnDataAnnotationsValidated()
        {
            MovieItem.GenresList = Selected.Select(x => new MoviesGenres { GenreId = int.Parse(x.Key) }).ToList();

            MovieItem.ActorList = SelectedActors.Select(x => new MoviesActors { PersonId = int.Parse(x.Character) }).ToList();

            if (!string.IsNullOrWhiteSpace(MovieItem.Poster))
            {
                ImageURL = null;
            }

            await OnValidMovieSubmit.InvokeAsync(null);
        }
    }
}