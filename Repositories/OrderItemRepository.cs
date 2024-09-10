using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCart_Hexaware.Repositories
{
    public class OrderItemRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItems> AddOrderItemAsync(OrderItems orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItems> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _dbContext.OrderItems.FindAsync(orderItemId);
        }

        public async Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderItems.Where(oi => oi.OrderID == orderId).ToListAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItems orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
