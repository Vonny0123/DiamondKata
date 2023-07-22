namespace DiamondKata.Program
{
    /// <summary>
    /// A class providing access to user's console inputs.
    /// </summary>
    public class UserInputManager : IUserInputManager<char>
    {
        private IConsoleInteractionProvider consoleInteractionProvider;

        /// <summary>
        /// Instatiates an instance of the class <see cref="UserInputManager"/>.
        /// </summary>
        /// <param name="consoleInteractionProvider">The console interaction manager.</param>
        public UserInputManager(IConsoleInteractionProvider consoleInteractionProvider)
        {
            this.consoleInteractionProvider = consoleInteractionProvider;
        }

        /// <inheritdoc/>
        public char GetUserInput()
        {
            var input = consoleInteractionProvider.GetFirstCommandLineArgument();

            char inputChar;
            if(!char.TryParse(input, out inputChar))
            {
                consoleInteractionProvider.WriteLine("Provide a single upper-case character:");
                inputChar = consoleInteractionProvider.ReadKey();
            }

            return inputChar;
        }
    }
}
