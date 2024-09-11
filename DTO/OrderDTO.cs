using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        [StringLength(255)]
        public string ShippingAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStatus { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public int UserID { get; set; }

        public int RestaurantID { get; set; }

        public int? DeliveryAgentID { get; set; }

        // List of order items
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
