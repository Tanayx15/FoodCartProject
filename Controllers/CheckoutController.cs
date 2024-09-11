using Microsoft.AspNetCore.Mvc;
using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using FoodCart_Hexaware.Services;
using Microsoft.AspNetCore.Authorization;

namespace FoodCart_Hexaware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Customer")]
    public class CheckoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderConfirmationService _orderConfirmationService;

        public CheckoutController(ApplicationDbContext context, OrderConfirmationService orderConfirmationService)
        {
            _context = context;
            _orderConfirmationService = orderConfirmationService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    var cartItems = await _context.Carts
                        .Where(c => c.UserID == model.UserId)
                        .Include(c => c.MenuItems)
                        .ToListAsync();

                    if (cartItems == null || !cartItems.Any())
                    {
                        return BadRequest("Your cart is empty.");
                    }

                    var restaurant = await _context.Restaurants .Where(r => r.RestaurantID == model.RestaurantID)
                                                                .Select(r => r.RestaurantName).FirstOrDefaultAsync();

                    var totalPrice = cartItems.Sum(item => item.Quantity * item.MenuItems.ItemPrice);

                    var estimatedDeliveryTime = DateTime.Now.AddMinutes(30);

                    var order = new Orders
                    {
                        UserID = model.UserId,
                        RestaurantID = model.RestaurantID,
                        TotalPrice = totalPrice,
                        ShippingAddress = model.ShippingAddress,
                        OrderStatus = "Pending",
                        OrderTime = DateTime.Now,
                        DeliveryTime = estimatedDeliveryTime,
                        OrderItems = cartItems.Select(item => new OrderItems
                        {
                            ItemID = item.ItemID,
                            Quantity = item.Quantity,
                            Price = item.MenuItems.ItemPrice
                        }).ToList()
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync(); 

                    
                    var payment = new Payment
                    {
                        Amount = totalPrice,
                        PaymentMethod = model.PaymentMethod,
                        PaymentStatus = "Pending",
                        TransDateTime = DateTime.Now,
                        OrderID = order.OrderID
                    };

                    _context.Payments.Add(payment);
                    await _context.SaveChangesAsync();

                    
                    switch (model.PaymentMethod.ToLower())
                    {
                        case "card":
                            if (model.CardPayment != null)
                            {
                                var cardPayment = new CardPayment
                                {
                                    CardNumber = model.CardPayment.CardNumber,
                                    CardHolderName = model.CardPayment.CardHolderName,
                                    PaymentId = payment.PaymentId
                                };
                                _context.CardPayment.Add(cardPayment);
                            }
                            break;

                        case "netbanking":
                            if (model.NetBankingPayment != null)
                            {
                                var netBankingPayment = new NetBankingPayment
                                {
                                    BankName = model.NetBankingPayment.BankName,
                                    AccountNumber = model.NetBankingPayment.AccountNumber,
                                    PaymentId = payment.PaymentId
                                };
                                _context.NetBankingPayment.Add(netBankingPayment);
                            }
                            break;

                        case "upi":
                            if (model.UpiPayment != null)
                            {
                                var upiPayment = new UpiPayment
                                {
                                    UpiId = model.UpiPayment.UpiId,
                                    PaymentId = payment.PaymentId
                                };
                                _context.UpiPayment.Add(upiPayment);
                            }
                            break;

                        case "cod":
                            payment.PaymentStatus = "COD - Pending";

                           
                            var deliveryAgent = await _context.DeliveryAgents
                                .Where(da => da.IsAvailable) 
                                .FirstOrDefaultAsync();

                            if (deliveryAgent == null)
                            {
                                return BadRequest("No available delivery agents at the moment.");
                            }

                           
                            order.DeliveryAgentID = deliveryAgent.DeliveryAgentID;
                            _context.Orders.Update(order);

                          
                            deliveryAgent.IsAvailable = false;
                            _context.DeliveryAgents.Update(deliveryAgent);

                            break;

                        default:
                            return BadRequest("Invalid payment method.");
                    }


                    await _context.SaveChangesAsync();

                    
                    _context.Carts.RemoveRange(cartItems);
                    await _context.SaveChangesAsync();


                    var itemNames = string.Join(", ", cartItems.Select(c => c.MenuItems.ItemName));

                 
                    await transaction.CommitAsync();


                    var userEmail = await _context.Users
                        .Where(u => u.UserID == model.UserId)
                        .Select(u => u.Email)
                        .FirstOrDefaultAsync();

                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        await _orderConfirmationService.SendOrderConfirmationEmailAsync(userEmail, order.OrderID);
                    }

                    return Ok(new
                    {
                        Message = $"You have successfully ordered {itemNames} from {restaurant}.",
                        OrderId = order.OrderID,
                        EstimatedDeliveryTime = estimatedDeliveryTime
                    });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
                }
            }
        }
    }
}
