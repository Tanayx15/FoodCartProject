using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserAuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            try
            {
               
                if (await _context.Users.AnyAsync(u => u.UserName == dto.Username || u.Email == dto.Email))
                {
                    return BadRequest("User with the same username or email already exists.");
                }

                var user = new Users
                {
                    UserName = dto.Username,
                    Password = dto.Password, 
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Role = dto.Role
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok("User created successfully.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "A database error occurred while creating the user. Please try again.");
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
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok("User deleted successfully.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "A database error occurred while deleting the user. Please try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
