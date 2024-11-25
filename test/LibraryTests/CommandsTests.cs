using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class CommandsTests
{
    [Test]
    public void BatlleStatusDebeResponderQueLaBatallaSigue()
    {
        // Arrange
        var mockFacade = new M<IFacade>();
        mockFacade.Setup(f => f.IsBattleOngoing()).Returns(true); // Simula que la batalla está activa
        Facade.Instance = mockFacade.Object;

        var mockContext = new Mock<SocketCommandContext>();
        var mockChannel = new Mock<IMessageChannel>();
        mockContext.Setup(c => c.Channel).Returns(mockChannel.Object);

        var command = new BattleStatus();
        command.SetContext(mockContext.Object);

        // Act
        await command.ExecuteAsync();

        // Assert
        mockChannel.Verify(c => c.SendMessageAsync("La batalla sigue en pie", false, null), Times.Once);
    }
    
}

