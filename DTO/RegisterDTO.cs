using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Phone]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is Required to access the features")]
        public string Role { get; set; }  // Customer / Admin / HotelManager

        public int? RestaurantID { get; set; }



    }
}
