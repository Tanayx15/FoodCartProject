using Microsoft.AspNetCore.Mvc;
using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart_Hexaware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ApplicationDbContext _dbContext;

        public CheckoutController(
            IOrderRepository orderRepository,
            IOrderItemsRepository orderItemsRepository,
            IPaymentRepository paymentRepository,
            ICartRepository cartRepository,
            ApplicationDbContext dbContext)
        {
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _paymentRepository = paymentRepository;
            _cartRepository = cartRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
        {
            if (request == null || request.CartItems == null || !request.CartItems.Any())
            {
                return BadRequest("Invalid cart details");
            }

            decimal totalPrice = request.CartItems.Sum(item => item.Price * item.Quantity - (item.Discount ?? 0));

            if (totalPrice != request.TotalPrice)
            {
                return BadRequest("Total price mismatch");
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Create a new Order
                var newOrder = new Orders
                {
                    UserID = request.UserId,
                    RestaurantID = request.RestaurantId,
                    ShippingAddress = request.ShippingDetails.Address,
                    OrderStatus = "Pending",
                    OrderTime = DateTime.Now,
                    TotalPrice = totalPrice
                };

                _dbContext.Orders.Add(newOrder);
                await _dbContext.SaveChangesAsync();

                // Add Order Items
                foreach (var item in request.CartItems)
                {
                    var orderItem = new OrderItems
                    {
                        OrderID = newOrder.OrderID,
                        ItemID = item.MenuItemId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Discount = item.Discount
                    };

                    _dbContext.OrderItems.Add(orderItem);
                }

                // Process Payment
                var payment = new Payment
                {
                    PaymentMethod = request.PaymentDetails.PaymentMethod,
                    PaymentStatus = "Processing",
                    TransDateTime = DateTime.Now,
                    Amount = totalPrice,
                    OrderID = newOrder.OrderID
                };

                _dbContext.Payments.Add(payment);
                await _dbContext.SaveChangesAsync(); // Ensure PaymentId is generated

                // Handle specific payment methods
                if (request.PaymentDetails.PaymentMethod == "Card")
                {
                    var cardPayment = new CardPayment
                    {
                        PaymentId = payment.PaymentId,
                        CardNumber = request.PaymentDetails.CardNumber,
                        CardHolderName = request.PaymentDetails.CardHolderName
                    };
                    _dbContext.CardPayment.Add(cardPayment);
                }
                else if (request.PaymentDetails.PaymentMethod == "NetBanking")
                {
                    var netBankingPayment = new NetBankingPayment
                    {
                        PaymentId = payment.PaymentId,
                        BankName = request.PaymentDetails.BankName,
                        AccountNumber = request.PaymentDetails.AccountNumber
                    };
                    _dbContext.NetBankingPayment.Add(netBankingPayment);
                }
                else if (request.PaymentDetails.PaymentMethod == "UPI")
                {
                    var upiPayment = new UpiPayment
                    {
                        PaymentId = payment.PaymentId,
                        UpiId = request.PaymentDetails.UPIId
                    };
                    _dbContext.UpiPayment.Add(upiPayment);
                }

                await _dbContext.SaveChangesAsync();

                // Clear Cart
                await _cartRepository.ClearCartAsync(request.CartId);

                await transaction.CommitAsync();

                return Ok(new { OrderId = newOrder.OrderID, Message = "Order placed successfully" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { Message = "An error occurred while processing your order", Error = ex.Message });
            }
        }
    }
}
