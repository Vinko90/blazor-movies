using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class PersonForm
    {
        [Parameter]
        public Person PersonItem { get; set; }
        
        [Parameter]
        public EventCallback OnValidPersonSubmit { get; set; }
    }
}
