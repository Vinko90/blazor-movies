using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Shared
{
    public partial class MovieForm
    {
        [Inject]
        public IPersonRepository personRepository { get; set; }

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
            return await personRepository.GetPeopleByName(searchText);
        }

        private async Task OnDataAnnotationsValidated()
        {
            MovieItem.GenresList = Selected.Select(x => new MoviesGenres { GenreId = int.Parse(x.Key) }).ToList();

            MovieItem.ActorList = SelectedActors.Select(x => new MoviesActors { PersonId = x.Id, CharacterName = x.Character }).ToList();

            if (!string.IsNullOrWhiteSpace(MovieItem.Poster))
            {
                ImageURL = null;
            }

            await OnValidMovieSubmit.InvokeAsync(null);
        }
    }
}