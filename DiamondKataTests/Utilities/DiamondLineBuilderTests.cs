using DiamondKata.Model;
using DiamondKata.Utilities;

namespace DiamondKataTests.Utilities
{
    [TestFixture]
    public class DiamondLineBuilderTests
    {
        private IAsciiArtBuilder<DiamondLineData> diamondLineBuilder;

        [SetUp]
        public void SetUp()
        {
            diamondLineBuilder = new DiamondLineBuilder();
        }

        [TestCase(0, "A")]
        [TestCase(1, " A ")]
        [TestCase(3, "   A   ")]
        public void TestDiamondLineBuilderConstructsFirstLineCorrectly(int outerSpaces, string expected)
        {
            // Arrange
            var lineData = new DiamondLineData('A', outerSpaces);

            // Act
            var result = diamondLineBuilder.Build(lineData);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase('B', 3, "   B B   ")]
        [TestCase('C', 1, " C C ")]
        [TestCase('Z', 0, "Z                                                 Z")]
        public void TestDiamondLineBuilderConstructsInternalLinesCorrectly(char character,  int outerSpaces, string expected)
        {
            // Arrange
            var lineData = new DiamondLineData(character, outerSpaces);

            // Act
            var result = diamondLineBuilder.Build(lineData);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase('Z', 1)]
        [TestCase('B', 26)]
        public void TestDiamondLineBuilderThrowsIfTooManyOuterSpaces(char character, int outerSpaces)
        {
            // Arrange
            var lineData = new DiamondLineData(character, outerSpaces);

            // Act / Assert
            Assert.Throws<ArgumentException>(() => diamondLineBuilder.Build(lineData));
        }
    }
}
