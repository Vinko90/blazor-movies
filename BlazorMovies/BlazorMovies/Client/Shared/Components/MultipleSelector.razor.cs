using BlazorMovies.Client.Helpers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class MultipleSelector
    {
        [Parameter]
        public List<MultipleSelectorModel> NotSelected { get; set; } = new List<MultipleSelectorModel>();

        [Parameter]
        public List<MultipleSelectorModel> Selected { get; set; } = new List<MultipleSelectorModel>();

        private string RemoveAllText = "<<";

        private void SelectItem(MultipleSelectorModel item)
        {
            NotSelected.Remove(item);
            Selected.Add(item);
        }

        private void DeSelectItem(MultipleSelectorModel item)
        {
            Selected.Remove(item);
            NotSelected.Add(item);
        }

        private void SelectAllItems()
        {
            Selected.AddRange(NotSelected);
            NotSelected.Clear();
        }

        private void DeselectAllItems()
        {
            NotSelected.AddRange(Selected);
            Selected.Clear();
        }
    }
}