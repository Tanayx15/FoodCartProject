using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
