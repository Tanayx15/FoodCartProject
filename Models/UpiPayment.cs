using System.ComponentModel.DataAnnotations;

namespace FoodCart_Hexaware.Models
{
    public class UpiPayment
    {
        [Key]
        public int UpiPaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string UpiId { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
