namespace FoodCart_Hexaware.DTO
{
    public class CartItem
    {
        public int MenuItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
    }
}
