using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTrackingController : ControllerBase
    {
        private readonly IOrderTrackingService _orderTrackingService;

        public OrderTrackingController(IOrderTrackingService orderTrackingService)
        {
            _orderTrackingService = orderTrackingService;
        }

        // GET: api/OrderTracking/{orderId}
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderTrackingService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // GET: api/OrderTracking/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var orders = await _orderTrackingService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        // PUT: api/OrderTracking/{orderId}/status
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderStatus newStatus)
        {
            var updatedOrder = await _orderTrackingService.UpdateOrderStatusAsync(orderId, newStatus);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

        // GET: api/OrderTracking/status/{status}
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetOrdersByStatus(OrderStatus status)
        {
            var orders = await _orderTrackingService.GetOrdersByStatusAsync(status);
            return Ok(orders);
        }
    }
}
