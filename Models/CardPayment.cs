using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [ForeignKey("Payments")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
