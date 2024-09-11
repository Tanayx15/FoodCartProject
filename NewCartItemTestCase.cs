using NUnit.Framework;
using Moq;
using FoodCart_Hexaware.Data; 
using FoodCart_Hexaware.Models; 
using System.Threading.Tasks;

[TestFixture]
public class CartItemRepositoryTests
{
    private Mock<IRepository<CartItem>> _cartItemRepositoryMock;
    private CartItem _testCartItem;

    [SetUp]
    public void SetUp()
    {
        _cartItemRepositoryMock = new Mock<IRepository<CartItem>>();
        _testCartItem = new CartItem { Id = 1, MenuItemId = 1, Quantity = 2 };
    }

    [Test]
    public async Task InsertCartItem_ShouldAddCartItem_WhenValidCartItemProvided()
    {
        // Arrange
        _cartItemRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<CartItem>()))
            .Returns(Task.CompletedTask);

        // Act
        await _cartItemRepositoryMock.Object.InsertAsync(_testCartItem);

        // Assert
        _cartItemRepositoryMock.Verify(repo => repo.InsertAsync(It.Is<CartItem>(c => c.MenuItemId == _testCartItem.MenuItemId)), Times.Once);
    }
}
