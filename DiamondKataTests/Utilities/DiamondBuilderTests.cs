using DiamondKata.Utilities;

namespace DiamondKataTests.Utilities
{
    [TestFixture]
    public class DiamondBuilderTests
    {
        private const string expectedA = @"A";

        private const string expectedB = @" A 
B B
 A ";

        private const string expectedC = @"  A  
 B B 
C   C
 B B 
  A  ";

        private IAsciiArtBuilder<char> diamondBuilder;

        [SetUp]
        public void SetUp()
        {
            var characterIndexConverter = new CharacterIndexConverter();
            diamondBuilder = new DiamondBuilder(
                new DiamondLineBuilder(characterIndexConverter),
                characterIndexConverter);
        }

        [TestCase('A', expectedA)]
        [TestCase('B', expectedB)]
        [TestCase('C', expectedC)]
        public void TestDiamondBuilderOnSmallInputs(char input, string expected)
        {
            // Arrange / Act
            var result = diamondBuilder.Build(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase('a')]
        [TestCase('z')]
        [TestCase('$')]
        [TestCase('£')]
        [TestCase('\n')]
        [TestCase('*')]
        public void TestDiamondBuilderThrowsOnInvalidInput(char input)
        {
            Assert.Throws<ArgumentException>(() => diamondBuilder.Build(input));
        }
    }
}
