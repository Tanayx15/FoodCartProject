using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.DTO
{
    public class RestaurantDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Restaurant name is required and cannot exceed 100 characters.")]
        public string RestaurantName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string RestaurantDescription { get; set; }

        [Required]
        [Phone]
        public string RestaurantPhone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email is required and cannot exceed 100 characters.")]
        public string RestaurantEmail { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Address is required and cannot exceed 255 characters.")]
        public string RestaurantAddress { get; set; }

        [Required]
        public TimeSpan OpeningHours { get; set; }

        [Required]
        public TimeSpan ClosingHours { get; set; }
    }
}
