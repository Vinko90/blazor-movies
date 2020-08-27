/// <summary>
/// Services class for dependency injection. This is not a default class in Blazor WASM
/// </summary>

namespace BlazorMovies.Client
{
    /// <summary>
    /// The instance of this object persist through the lifespan of the application
    /// </summary>
    public class SingletonService
    {
        public int Value { get; set; }
    }

    /// <summary>
    /// A new instance of this object is created every time is needed, therefore variables are disposed
    /// </summary>
    public class TransientService
    {
        public int Value { get; set; }
    }
}
