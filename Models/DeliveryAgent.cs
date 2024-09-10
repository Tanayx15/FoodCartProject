using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class DeliveryAgent
    {
        [Key]
        public int DeliveryAgentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        public bool IsAvailable { get; set; } // Indicates if the agent is currently available



        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
