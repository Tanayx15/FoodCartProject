using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.EntityFrameworkCore;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Payment> AddPaymentAsync(Payment payment)
    {
        _dbContext.Payments.Add(payment);
        await _dbContext.SaveChangesAsync();
        return payment;
    }

    public async Task<Payment> GetPaymentByIdAsync(int paymentId)
    {
        return await _dbContext.Payments.FindAsync(paymentId);
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByOrderIdAsync(int orderId)
    {
        return await _dbContext.Payments.Where(p => p.OrderID == orderId).ToListAsync();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _dbContext.Payments.Update(payment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(int paymentId)
    {
        var payment = await _dbContext.Payments.FindAsync(paymentId);
        if (payment != null)
        {
            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
