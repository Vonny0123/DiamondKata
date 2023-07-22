using DiamondKata.Model;

namespace DiamondKata.Utilities
{
    /// <summary>
    /// A class for building Diamond ASCII art based on a given character
    /// </summary>
    public class DiamondBuilder : IAsciiArtBuilder<char>
    {
        private readonly IAsciiArtBuilder<DiamondLineData> diamondLineBuilder;
        private readonly IConverter<char, int> characterIndexConverter;

        /// <summary>
        /// Instantiates an instance of the class <see cref="DiamondBuilder"/>
        /// </summary>
        /// <param name="diamondLineBuilder">The line builder to use for constructing lines of the art.</param>
        public DiamondBuilder(
            IAsciiArtBuilder<DiamondLineData> diamondLineBuilder,
            IConverter<char, int> characterIndexConverter)
        { 
            this.diamondLineBuilder = diamondLineBuilder;
            this.characterIndexConverter = characterIndexConverter;
        }

        /// <inheritdoc/>
        public string Build(char input)
        {
            var characterIndex = characterIndexConverter.Convert(input);

            var lines = Enumerable.Range(0, characterIndex + 1)
                .Select(x => new DiamondLineData(characterIndexConverter.Convert(x), characterIndex - x))
                .Select(diamondLineBuilder.Build)
                .ToList();

            lines = lines
                .Concat(lines
                    .SkipLast(1)
                    .Reverse())
                .ToList();

            return string.Join(Environment.NewLine, lines);
        }
    }
}
