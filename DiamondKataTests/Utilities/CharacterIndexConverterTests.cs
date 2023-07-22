using DiamondKata.Utilities;

namespace DiamondKataTests.Utilities
{
    [TestFixture]
    public class CharacterIndexConverterTests
    {
        private IConverter<char, int> characterIndexConverter;

        [SetUp]
        public void SetUp()
        {
            this.characterIndexConverter = new CharacterIndexConverter();
        }

        [TestCase('A', 0)]
        [TestCase('B', 1)]
        [TestCase('Z', 25)]
        public void TestCharacterToIndexConversionForValidInputs(char character, int expected)
        {
            // Arrange / Act
            var result = characterIndexConverter.Convert(character);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('z')]
        [TestCase('*')]
        [TestCase('_')]
        [TestCase('$')]
        [TestCase(' ')]
        [TestCase('\n')]
        public void TestCharacterToIndexConversionThrowsForInvalidInputs(char character)
        {
            Assert.Throws<ArgumentException>(() => characterIndexConverter.Convert(character));
        }

        [TestCase(0, 'A')]
        [TestCase(1, 'B')]
        [TestCase(25, 'Z')]
        public void TestIndexToCharacterConversionForValidInputs(int index, char expected)
        {
            // Arrange / Act
            var result = characterIndexConverter.Convert(index);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [TestCase(26)]
        [TestCase(int.MaxValue)]
        public void TestIndexToCharacterConversionForInvalidInputs(int index)
        {
            Assert.Throws<ArgumentException>(() => characterIndexConverter.Convert(index));
        }
    }
}
