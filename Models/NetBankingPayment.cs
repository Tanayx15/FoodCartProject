using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCart_Hexaware.Models
{
    public class NetBankingPayment
    {
        [Key]
        public int NetBankingPaymentId { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [ForeignKey("Payments")]

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }

}
