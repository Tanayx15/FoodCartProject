using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.Repositories
{
    public interface IOrderRepository
    {
        Task<Orders> CreateOrderAsync(Orders order);
        Task<Orders> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int orderId);
    }


}
