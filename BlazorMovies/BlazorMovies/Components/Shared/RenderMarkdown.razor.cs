using Markdig;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Components.Shared
{
    public partial class RenderMarkdown
    {
        private string htmlContent;

        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(MarkdownContent))
            {
                htmlContent = Markdown.ToHtml(MarkdownContent);
            }
            else
            {
                htmlContent = null;
            }
        }

        [Parameter]
        public string MarkdownContent { get; set; }
    }
}