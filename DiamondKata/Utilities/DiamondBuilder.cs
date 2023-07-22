using DiamondKata.Model;
using System.Linq;

namespace DiamondKata.Utilities
{
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

        public string Build(char input)
        {
            throw new NotImplementedException();
        }
    }
}
