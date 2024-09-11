using NUnit.Framework;
using Moq;
using FoodCart_Hexaware.Data; 
using FoodCart_Hexaware.Models; 
using System.Threading.Tasks;

[TestFixture]
public class MenuItemRepositoryTests
{
    private Mock<IRepository<MenuItem>> _menuItemRepositoryMock;
    private MenuItem _testMenuItem;

    [SetUp]
    public void SetUp()
    {
        _menuItemRepositoryMock = new Mock<IRepository<MenuItem>>();
        _testMenuItem = new MenuItem { Id = 1, Name = "Pizza", Price = 9.99M };
    }

    [Test]
    public async Task InsertMenuItem_ShouldAddMenuItem_WhenValidMenuItemProvided()
    {
        // Arrange
        _menuItemRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<MenuItem>()))
            .Returns(Task.CompletedTask);

        // Act
        await _menuItemRepositoryMock.Object.InsertAsync(_testMenuItem);

        // Assert
        _menuItemRepositoryMock.Verify(repo => repo.InsertAsync(It.Is<MenuItem>(m => m.Name == _testMenuItem.Name)), Times.Once);
    }
}
