
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class InputPassword : InputBase<string>
    {
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
