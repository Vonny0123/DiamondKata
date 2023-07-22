namespace DiamondKata.Model
{
    /// <summary>
    /// A Model class containing the data required to construct a line of diamond ASCII art. 
    /// </summary>
    public class DiamondLineData
    {
        /// <summary>
        /// Initialises an instance of the class <see cref="DiamondLineData"/>.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="outerSpaces">The number of outer spaces.</param>
        public DiamondLineData(char character, int outerSpaces)
        {
            Character = character;
            OuterSpaces = outerSpaces;
        }

        /// <summary>
        /// Gets the character to use on the line when writing a line of the Diamond.
        /// </summary>
        public char Character { get; }

        /// <summary>
        /// Gets the number of white space characters to leave outside the two characters.
        /// </summary>
        public int OuterSpaces { get; }
    }
}
