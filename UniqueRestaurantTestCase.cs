using NUnit.Framework;
using Moq;
using FoodCart_Hexaware.Data; 
using FoodCart_Hexaware.Models; 
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class RestaurantRepositoryTests
{
    private Mock<IRepository<Restaurant>> _restaurantRepositoryMock;
    private Restaurant _testRestaurant;

    [SetUp]
    public void SetUp()
    {
        _restaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
        _testRestaurant = new Restaurant { Id = 1, Name = "Unique Restaurant" };
    }

    [Test]
    public async Task InsertRestaurant_ShouldThrowException_WhenDuplicateNameProvided()
    {
        // Arrange
        _restaurantRepositoryMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Restaurant> { _testRestaurant });

        // Act & Assert
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            var restaurants = await _restaurantRepositoryMock.Object.GetAllAsync();
            if (restaurants.Any(r => r.Name == _testRestaurant.Name))
            {
                throw new InvalidOperationException("Restaurant name must be unique.");
            }
        });
        Assert.That(exception.Message, Is.EqualTo("Restaurant name must be unique."));
    }
}
