using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class GenericList<TItem>
    {
        [Parameter]
        public RenderFragment NullTemplate { get; set; }

        [Parameter]
        public RenderFragment EmptyCountTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> ElementTemplate { get; set; }

        [Parameter]
        public RenderFragment WholeListTemplate { get; set; }

        [Parameter]
        public List<TItem> List { get; set; }
    }
}
