using AutoMapper;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Server.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Person, Person>()
                .ForMember(x => x.Picture, option => option.Ignore());

            CreateMap<Movie, Movie>()
                .ForMember(x => x.Poster, option => option.Ignore());
        }
    }
}
