namespace DiamondKata.Program
{
    internal class ConsoleInteractionProvider : IConsoleInteractionProvider
    {
        /// <inheritdoc/>
        public string? GetFirstCommandLineArgument() => Environment.GetCommandLineArgs().ElementAtOrDefault(1);

        /// <inheritdoc/>
        public char ReadKey() => Console.ReadKey(true).KeyChar;

        /// <inheritdoc/>
        public void WriteError(string text) => Console.Error.WriteLine(text);

        /// <inheritdoc/>
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
