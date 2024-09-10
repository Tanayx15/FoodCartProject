using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodCart_Hexaware.Models
{
    public class Users
    {
        [Required]
        [Key]
        public int UserID { get; set; }
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

        public string Role { get; set; }  //Customer /Admin/ HotelManager

        //Navigation Property
        [JsonIgnore]
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
        [JsonIgnore]
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        [JsonIgnore]
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        [JsonIgnore]
        public ICollection<DeliveryAgent> DeliveryAgents { get; set; } = new List<DeliveryAgent>();




    }
}
