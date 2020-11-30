namespace BlazorMovies.Components.Helpers
{
    /// <summary>
    /// MultipleSelectorModel class implementation.
    /// Provide a model class for populating object rapresentation in multi selector lookup.
    /// </summary>
    public struct MultipleSelectorModel
    {
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public MultipleSelectorModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// The key of the given collection
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value of the given collection
        /// </summary>
        public string Value { get; set; }
    }
}