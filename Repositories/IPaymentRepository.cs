using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<Payment>> GetPaymentsByOrderIdAsync(int orderId);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int paymentId);
    }

}

