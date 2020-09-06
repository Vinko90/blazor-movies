using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class CustomTypeahead<TItem>
    {
        #region Parameters

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public int MinimumLenght { get; set; } = 3;

        [Parameter]
        public int Debounce { get; set; } = 300;

        [Parameter]
        public Func<string, Task<IEnumerable<TItem>>> SearchMethod { get; set; }

        [Parameter]
        public RenderFragment<TItem> ResultTemplate { get; set; }

        [Parameter]
        public RenderFragment NotFoundTemplate { get; set; }

        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        #endregion

        #region Internal Variables

        private bool IsSearching = false;

        private bool IsShowingSuggestions = false;

        private string _searchText = string.Empty;

        private Timer _debounceTimer;

        protected TItem[] Suggestions { get; set; } = new TItem[0];

        private bool IsMouseInSuggestion = false;

        #endregion

        protected override void OnInitialized()
        {
            _debounceTimer = new Timer
            {
                Interval = Debounce,
                AutoReset = false
            };
            _debounceTimer.Elapsed += Search;
        }

        protected async void Search(object source, ElapsedEventArgs e)
        {
            IsSearching = true;
            IsShowingSuggestions = false;
            await InvokeAsync(StateHasChanged);

            Suggestions = (await SearchMethod.Invoke(_searchText)).ToArray();
            IsSearching = false;
            IsShowingSuggestions = true;
            await InvokeAsync(StateHasChanged);
        }

        private string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                if (value.Length == 0)
                {
                    IsShowingSuggestions = false;
                    _debounceTimer.Stop();
                    Suggestions = new TItem[0];
                }
                else if (value.Length >= MinimumLenght)
                {
                    _debounceTimer.Stop();
                    _debounceTimer.Start();
                }
            }
        }

        private void ShowSuggestions()
        {
            if (Suggestions.Any())
            {
                IsShowingSuggestions = true;
            }
        }

        private void OnFocusOut()
        {
            if (!IsMouseInSuggestion)
            {
                IsShowingSuggestions = false;
            }
        }

        private bool ShouldShowSuggestions()
        {
            return IsShowingSuggestions && Suggestions.Any();
        }

        private async Task SelectSuggestion(TItem item)
        {
            SearchText = "";
            await ValueChanged.InvokeAsync(item);
        }

        private bool ShowNotFound()
        {
            return !Suggestions.Any() && IsShowingSuggestions;
        }

        private void OnMouseOverSuggestion()
        {
            IsMouseInSuggestion = true;
        }

        private void OnMouseOutSuggestion()
        {
            IsMouseInSuggestion = false;
        }
    }
}