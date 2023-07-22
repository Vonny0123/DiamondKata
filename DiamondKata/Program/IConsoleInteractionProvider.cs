namespace DiamondKata.Program
{
    /// <summary>
    /// An interface to be implemented by classes interacting with the console.
    /// </summary>
    public interface IConsoleInteractionProvider
    {
        /// <summary>
        /// Gets the first command line argument provided by the user.
        /// </summary>
        /// <returns>The first command line argument.</returns>
        public string GetFirstCommandLineArgument();

        /// <summary>
        /// Reads and returns the character associated with the key entered by the user.
        /// </summary>
        /// <returns>The character entered by the user.</returns>
        public char ReadKey();

        /// <summary>
        /// Writes the given text to stdout.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void WriteLine(string text);

        /// <summary>
        /// Writes the given text to stderror.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void WriteError(string text);
    }
}
