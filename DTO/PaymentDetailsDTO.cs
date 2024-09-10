namespace FoodCart_Hexaware.DTO
{
    public class PaymentDetailsDTO
    {
        public string PaymentMethod { get; set; } // Can be 'NetBanking', 'Card', 'UPI', 'COD'
        public string CardNumber { get; set; } // Only needed for Card payments
        public string UPIId { get; set; } // Only needed for UPI payments
        public string BankName { get; set; } // Only needed for Net Banking payments

        public int OrderID { get; set; }

        public string CardHolderName { get; set; }

        public string AccountNumber { get; set; }   
    }
}
