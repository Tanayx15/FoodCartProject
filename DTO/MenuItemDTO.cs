using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class MenuItemDTO
    {

        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string CuisineType { get; set; }

        [Required]
        public string TasteInfo { get; set; }

        [Required]
        [StringLength(50)]
        public string AvailabilityStatus { get; set; }

        [Required]
        public string DietaryInfo { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
