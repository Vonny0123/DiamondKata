namespace DiamondKata.Program
{
    /// <summary>
    /// An interface to be implemented by a class retrieving input from the user of type <see cref="T"/>
    /// </summary>
    public interface IUserInputManager<T>
    {
        public T GetUserInput();
    }
}
