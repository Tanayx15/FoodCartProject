using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
        [ForeignKey("MenuItems")]
        public int ItemID { get; set; }
        [ForeignKey("Restaurant")]
        public int RestID { get; set; }

        [Required]
        [StringLength(50)]
        public string NotificationType { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime NotificationTime { get; set; }

        // Navigation properties
        public Users? Users { get; set; }
        public MenuItems? MenuItems { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
