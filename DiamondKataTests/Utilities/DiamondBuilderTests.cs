using DiamondKata.Model;
using DiamondKata.Utilities;

using Moq;

namespace DiamondKataTests.Utilities
{
    [TestFixture]
    public class DiamondBuilderTests
    {
        private IAsciiArtBuilder<char> diamondBuilder;
        private Mock<IAsciiArtBuilder<DiamondLineData>> diamondLineBuilderStub;
        private Mock<IConverter<char, int>> characterIndexConverterStub;

        [SetUp]
        public void SetUp()
        {
            characterIndexConverterStub = new Mock<IConverter<char, int>>();
            diamondLineBuilderStub = new Mock<IAsciiArtBuilder<DiamondLineData>>();
            diamondBuilder = new DiamondBuilder(diamondLineBuilderStub.Object, characterIndexConverterStub.Object);
        }

        [Test]
        public void TestDiamondLineBuilderIsCalledCorrectly()
        {
            // Arrange
            var characterIndex = 3;

            characterIndexConverterStub
                .Setup(x => x.Convert(It.IsAny<char>()))
                .Returns(characterIndex);

            characterIndexConverterStub
                .SetupSequence(x => x.Convert(It.IsAny<int>()))
                .Returns('A')
                .Returns('B')
                .Returns('C')
                .Returns('D');

            diamondLineBuilderStub
                .SetupSequence(x => x.Build(It.IsAny<DiamondLineData>()))
                .Returns("Line 0")
                .Returns("Line 1")
                .Returns("Line 2")
                .Returns("Line 3");

            var expected = @"Line 0
Line 1
Line 2
Line 3
Line 2
Line 1
Line 0";
            
            // Act
            var result = diamondBuilder.Build('D');

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(diamondLineBuilderStub.Invocations.Count, Is.EqualTo(4));

            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(0).Arguments.Single()).Character, Is.EqualTo('A'));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(0).Arguments.Single()).OuterSpaces, Is.EqualTo(3));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(1).Arguments.Single()).Character, Is.EqualTo('B'));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(1).Arguments.Single()).OuterSpaces, Is.EqualTo(2));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(2).Arguments.Single()).Character, Is.EqualTo('C'));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(2).Arguments.Single()).OuterSpaces, Is.EqualTo(1));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(3).Arguments.Single()).Character, Is.EqualTo('D'));
            Assert.That(((DiamondLineData)diamondLineBuilderStub.Invocations.ElementAt(3).Arguments.Single()).OuterSpaces, Is.EqualTo(0));
        }

        [Test]
        public void TestDiamondBuilderThrowsInnerErrors()
        {
            // Arrange
            characterIndexConverterStub
                .Setup(x => x.Convert(It.IsAny<char>()))
                .Throws(new ArgumentException("Inner exception error message."));

            // Act / Assert
            Assert.Throws<ArgumentException>(() => diamondBuilder.Build('*'));
        }
    }
}
