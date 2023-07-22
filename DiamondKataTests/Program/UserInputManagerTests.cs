using DiamondKata.Program;
using Moq;

namespace DiamondKataTests.Program
{
    [TestFixture]
    public class UserInputManagerTests
    {
        Mock<IConsoleInteractionProvider> consoleInteractionProviderMock;
        IUserInputManager<char> userInputManager;

        [SetUp]
        public void Setup()
        {
            consoleInteractionProviderMock = new Mock<IConsoleInteractionProvider>();
            userInputManager = new UserInputManager(consoleInteractionProviderMock.Object);
        }

        [TestCase("A", 'A')]
        [TestCase("B", 'B')]
        [TestCase("Z", 'Z')]
        public void TestReturnsCorrectForValidInput(string input, char expected)
        {
            // Arrange
            consoleInteractionProviderMock
                .Setup(x => x.GetFirstCommandLineArgument())
                .Returns(input);

            // Act
            var result = userInputManager.GetUserInput();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("multiple letters")]
        [TestCase("")]
        public void TestAllowsUserToEnterValidValueIfInvalidString(string input)
        {
            // Arrange
            consoleInteractionProviderMock
                .Setup(x => x.GetFirstCommandLineArgument())
                .Returns(input);

            consoleInteractionProviderMock
                .Setup(x => x.ReadKey())
                .Returns('A');

            // Act
            var result = userInputManager.GetUserInput();

            // Assert
            Assert.That(result, Is.EqualTo('A'));
        }
    }
}
