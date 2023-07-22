namespace DiamondKata.Utilities
{
    /// <summary>
    /// An interface to be implemented by classes which convert bijectively between two types.
    /// </summary>
    /// <typeparam name="T">The first type which can be converted into the second type.</typeparam>
    /// <typeparam name="U">The second type which can be converted into the first type.</typeparam>
    public interface IConverter<T, U>
    {
        /// <summary>
        /// Converts an instance of type <see cref="T"/> to an instance of type <see cref="U"/>.
        /// </summary>
        /// <param name="input">The object to convert.</param>
        /// <returns>The converted object.</returns>
        U Convert(T input);

        /// <summary>
        /// Converts an instance of type <see cref="U"/> to an instance of type <see cref="T"/>.
        /// </summary>
        /// <param name="input">The object to convert.</param>
        /// <returns>The converted object.</returns>
        T Convert(U input);
    }
}
