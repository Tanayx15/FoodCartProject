using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.DTO
{
    public class DashBoardDTO
    {
        public Restaurant Restaurant { get; set; }

        public List<Orders>? Orders { get; set; }

        public List<MenuItems>? MenuItems { get; set; }
      
    }

}
