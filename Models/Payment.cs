using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCart_Hexaware.Models
{
    public class Payment
    {
        [Required]
        [Key]
        public int PaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; }
        [Required]
        public DateTime TransDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public int OrderID { get; set; }

        //Reference Navigation Property
        public Orders? Orders { get; set; }

        public NetBankingPayment? NetBankingPayment { get; set; }
        public UpiPayment? UpiPayment { get; set; }
        public CardPayment? CardPayment { get; set; }
    }
}
