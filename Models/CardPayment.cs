using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class CardPayment
    {
        [Key]
        public int CardPaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CardHolderName { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
