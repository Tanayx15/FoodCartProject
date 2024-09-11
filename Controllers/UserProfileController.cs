using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FoodCart_Hexaware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Customer")]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDTO>> GetUserProfile(int id)
        {
            // Fetch the user without including related data
            var user = await _context.Users
                                     .Where(u => u.UserID == id)
                                     .Select(u => new UserProfileDTO
                                     {
                                         UserID = u.UserID,
                                         UserName = u.UserName,
                                         Email = u.Email,
                                         PhoneNumber = u.PhoneNumber,
                                         Role = u.Role
                                     })
                                     .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }

        [HttpPut("ChangeEmail/{id}")]
        public async Task<IActionResult> ChangeEmail(int id, [FromBody] string newEmail)
        {
            if (!new EmailAddressAttribute().IsValid(newEmail))
            {
                return BadRequest(new { message = "Invalid email format" });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            user.Email = newEmail;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Email updated successfully" });
        }

        [HttpPut("UpdateAlternativePhone/{id}")]
        public async Task<IActionResult> UpdateAlternativePhone(int id, [FromBody] string newPhoneNumber)
        {
            var phoneNumberPattern = @"^\d{10}$"; 
            if (!Regex.IsMatch(newPhoneNumber, phoneNumberPattern))
            {
                return BadRequest(new { message = "Phone number must be 10 digits." });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

           
            user.AlternativePhoneNumber = newPhoneNumber;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Alternative phone number updated successfully" });
        }

        [HttpPut("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDTO passwordData)
        {
            if (passwordData.NewPassword.Length < 8)
            {
                return BadRequest(new { message = "Password must be at least 8 characters long" });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            if (!BCrypt.Net.BCrypt.Verify(passwordData.CurrentPassword, user.Password))
            {
                return BadRequest(new { message = "Current password is incorrect" });
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(passwordData.NewPassword);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Password changed successfully" });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] UserProfileDTO updatedUser)
        {
            if (id != updatedUser.UserID)
            {
                return BadRequest(new { message = "User ID mismatch" });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound(new { message = "User not found" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.UserID == id);
        }
    }
}

