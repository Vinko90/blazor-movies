using Microsoft.AspNetCore.Components;
using System;
using System.Linq.Expressions;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class InputMarkdown<TValue>
    {
        [Parameter]
        public Expression<Func<TValue>> For { get; set; }

        [Parameter]
        public string Label { get; set; }
    }
}