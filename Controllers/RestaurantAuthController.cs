using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RestaurantAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public RestaurantAuthController(ApplicationDbContext context)
        {
            _context = context;

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Register(RestaurantDTO dto)
        {
            try
            {
                if (await _context.Restaurants.AnyAsync(r => r.RestaurantName == dto.RestaurantName))
                {
                    return BadRequest("Restaurant already exists");
                }

                var restaurant = new Restaurant
                {
                    RestaurantName = dto.RestaurantName,
                    RestaurantDescription = dto.RestaurantDescription,
                    RestaurantPhone = dto.RestaurantPhone,
                    RestaurantEmail = dto.RestaurantEmail,
                    RestaurantAddress = dto.RestaurantAddress,
                    OpeningHours = dto.OpeningHours,
                    ClosingHours = dto.ClosingHours,
                };

                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return Ok("Restaurant created successfully.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "A database error occurred while registering the restaurant. Please try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant == null)
                {
                    return NotFound("Restaurant not found.");
                }

                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
                return Ok("Restaurant deleted successfully.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "A database error occurred while deleting the restaurant. Please try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
