using DiamondKata.Model;
using System.Text;

namespace DiamondKata.Utilities
{
    /// <summary>
    /// A class for constructing a line of diamond ASCII art.
    /// </summary>
    public class DiamondLineBuilder : IAsciiArtBuilder<DiamondLineData>
    {
        private const int MaxLineLength = 51;
        private const char SpaceCharacter = ' ';

        private readonly IConverter<char, int> characterIndexConverter;

        /// <summary>
        /// Instantiates an instance of the class <see cref="DiamondLineBuilder"/>
        /// </summary>
        /// <param name="characterIndexConverter"></param>
        public DiamondLineBuilder(IConverter<char, int> characterIndexConverter)
        {
            this.characterIndexConverter = characterIndexConverter;
        }

        /// <inheritdoc/>
        public string Build(DiamondLineData input)
        {
            var innerSpaces = 2 * characterIndexConverter.Convert(input.Character) - 1;

            var lineBuilder = new StringBuilder();

            lineBuilder.Append(SpaceCharacter, input.OuterSpaces);
            lineBuilder.Append(input.Character);

            if (innerSpaces > 0)
            {
                lineBuilder.Append(SpaceCharacter, innerSpaces);
                lineBuilder.Append(input.Character);
            }

            lineBuilder.Append(SpaceCharacter, input.OuterSpaces);
            var line = lineBuilder.ToString();

            if (line.Length > MaxLineLength)
            {
                throw new ArgumentException(
                    $"The input data resulted in a line of length greater than the maximum possible line ({MaxLineLength})");
            }

            return line;
        }
    }
}
