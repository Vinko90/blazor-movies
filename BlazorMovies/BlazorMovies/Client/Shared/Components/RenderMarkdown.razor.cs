using Markdig;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class RenderMarkdown
    {
        [Parameter]
        public string MarkdownContent { get; set; }

        private string HTMLContent;

        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(MarkdownContent))
            {
                HTMLContent = Markdown.ToHtml(MarkdownContent);
            }
            else
            {
                HTMLContent = null;
            }
        }
    }
}