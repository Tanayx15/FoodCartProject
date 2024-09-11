using NUnit.Framework;
using Moq;
using FoodCart_Hexaware.Data; 
using FoodCart_Hexaware.Models; 
using System.Threading.Tasks;

[TestFixture]
public class UserRepositoryTests
{
    private Mock<IRepository<User>> _userRepositoryMock;
    private User _testUser;

    [SetUp]
    public void SetUp()
    {
        _userRepositoryMock = new Mock<IRepository<User>>();
        _testUser = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
    }

    [Test]
    public async Task InsertUser_ShouldAddUser_WhenValidUserProvided()
    {
        // Arrange
        _userRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        // Act
        await _userRepositoryMock.Object.InsertAsync(_testUser);

        // Assert
        _userRepositoryMock.Verify(repo => repo.InsertAsync(It.Is<User>(u => u.Email == _testUser.Email)), Times.Once);
    }
}
