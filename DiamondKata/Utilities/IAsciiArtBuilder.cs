namespace DiamondKata.Utilities
{
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
