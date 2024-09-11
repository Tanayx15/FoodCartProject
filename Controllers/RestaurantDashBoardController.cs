using FoodCart_Hexaware.DTOs;
using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Hotel Owner")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: api/restaurant/dashboard
        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                var dashboardData = _restaurantService.GetDashboardData(parsedUserId);
                return Ok(dashboardData);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/restaurant/menuitem
        [HttpPost("menuitem")]
        public IActionResult AddMenuItem([FromBody] MenuItemDTO menuItemDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.AddMenuItem(parsedUserId, menuItemDTO);
                return CreatedAtAction(nameof(GetMenuItems), new { restaurantId = menuItemDTO.CategoryID }, menuItemDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/restaurant/menuitems/{restaurantId}
        [HttpGet("menuitems/{restaurantId}")]
        public IActionResult GetMenuItems(int restaurantId)
        {
            var menuItems = _restaurantService.GetMenuItems(restaurantId);
            return Ok(menuItems);
        }

        // PUT: api/restaurant/menuitem/{itemId}
        [HttpPut("menuitem/{itemId}")]
        public IActionResult UpdateMenuItem(int itemId, [FromBody] MenuItemDTO menuItemDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.UpdateMenuItem(parsedUserId, itemId, menuItemDTO);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/restaurant/menuitem/{itemId}
        [HttpDelete("menuitem/{itemId}")]
        public IActionResult DeleteMenuItem(int itemId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.DeleteMenuItem(parsedUserId, itemId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/restaurant/categories/{restaurantId}
        [HttpGet("categories/{restaurantId}")]
        public IActionResult GetCategories(int restaurantId)
        {
            var categories = _restaurantService.GetCategories(restaurantId);
            return Ok(categories);
        }

        // POST: api/restaurant/category
        [HttpPost("category")]
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.AddCategory(parsedUserId, categoryDTO);
                return CreatedAtAction(nameof(GetCategories), new { restaurantId = categoryDTO.CategoryID }, categoryDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/restaurant/category/{categoryId}
        [HttpPut("category/{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDTO categoryDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.UpdateCategory(parsedUserId, categoryId, categoryDTO);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/restaurant/category/{categoryId}
        [HttpDelete("category/{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.DeleteCategory(parsedUserId, categoryId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/restaurant/orders/{restaurantId}
        [HttpGet("orders/{restaurantId}")]
        public IActionResult GetOrders(int restaurantId)
        {
            var orders = _restaurantService.GetOrders(restaurantId);
            return Ok(orders);
        }

        // PUT: api/restaurant/order/{orderId}
        [HttpPut("order/{orderId}")]
        public IActionResult UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.UpdateOrderStatus(parsedUserId, orderId, status);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/restaurant/order/{orderId}
        [HttpGet("order/{orderId}")]
        public IActionResult GetOrderDetails(int orderId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                var orderDetails = _restaurantService.GetOrderDetails(parsedUserId, orderId);
                return Ok(orderDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        // PUT: api/restaurant/menuitem/{itemId}/outofstock
        [HttpPut("menuitem/{itemId}/outofstock")]
        public IActionResult MarkMenuItemAsOutOfStock(int itemId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var parsedUserId))
            {
                return Unauthorized("Invalid user ID.");
            }

            try
            {
                _restaurantService.MarkMenuItemAsOutOfStock(parsedUserId, itemId);
                return NoContent(); // Successfully marked as out of stock
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
