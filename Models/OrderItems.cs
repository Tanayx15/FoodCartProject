using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class OrderItems
    {
        [Required]
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be a positive value.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [ForeignKey("MenuItems")]
        public int ItemID { get; set; }

        public Orders? Orders { get; set; }
        public MenuItems? MenuItems { get; set; }
    }
}
