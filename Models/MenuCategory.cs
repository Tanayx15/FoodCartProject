using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodCart_Hexaware.Models
{
    public class MenuCategory
    {
        [Required]
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        [JsonIgnore]
        public ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();

    }
}
