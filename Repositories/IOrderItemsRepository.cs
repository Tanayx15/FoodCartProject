using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.Repositories
{
    public interface IOrderItemsRepository
    {
        Task<OrderItems> AddOrderItemAsync(OrderItems orderItem);
        Task<OrderItems> GetOrderItemByIdAsync(int orderItemId);
        Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId);
        Task UpdateOrderItemAsync(OrderItems orderItem);
        Task DeleteOrderItemAsync(int orderItemId);
    }

}
