namespace DiamondKata.Utilities
{
    /// <summary>
    /// An interface to be implemented by classes which construct string ASCII art.
    /// </summary>
    /// <typeparam name="T">The type used to construct the art.</typeparam>
    public interface IAsciiArtBuilder<T>
    {
        /// <summary>
        /// Builds the ASCII art based on the given input.
        /// </summary>
        /// <param name="input">The input used to generate the ASCII art.</param>
        /// <returns></returns>
        public string Build(T input);
    }
}
