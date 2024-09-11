using FoodCart_Hexaware.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.DTOs
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        
        public List<MenuItemDTO> MenuItems { get; set; }
    }
}
