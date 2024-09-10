using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.DTO
{
    public class CheckoutRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public ShippingDetailsDTO ShippingDetails { get; set; }
        public List<CartItem> CartItems { get; set; }
        public PaymentDetailsDTO PaymentDetails { get; set; }
    }
}
