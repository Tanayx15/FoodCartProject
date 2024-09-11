using System;

namespace FoodCart_Hexaware.DTOs
{
    public class OrderItemDTO
    {
        public int OrderItemID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        public int OrderID { get; set; }

        public int ItemID { get; set; }

        public string ItemName { get; set; } // To include item name if needed

        public decimal ItemPrice { get; set; } // To include item price if needed

        public decimal TotalPrice => (Price - (Discount ?? 0)) * Quantity; // Calculated total price after discount
    }
}
