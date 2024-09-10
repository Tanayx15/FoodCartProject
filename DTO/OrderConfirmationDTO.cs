namespace FoodCart_Hexaware.DTO
{
    public class OrderConfirmationDTO
    {
        public int CartId { get; set; } // Cart items to be ordered
        public ShippingDetailsDTO ShippingDetails { get; set; }
        public PaymentDetailsDTO PaymentDetails { get; set; }
    }
}
