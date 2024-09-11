using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCart_Hexaware.Models
{
    public class UpiPayment
    {
        [Key]
        public int UpiPaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string UpiId { get; set; }
        [Required]
        [ForeignKey("Payments")]

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
