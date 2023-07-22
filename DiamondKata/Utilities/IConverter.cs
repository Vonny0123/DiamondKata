namespace DiamondKata.Utilities
{
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
