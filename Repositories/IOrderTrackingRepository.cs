using System.Collections.Generic;
using System.Threading.Tasks;
using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.Repositories
{
    public interface IOrderTrackingRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task<Order> TrackOrderProgressAsync(int orderId);
    }
}
