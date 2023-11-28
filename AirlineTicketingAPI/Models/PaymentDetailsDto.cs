using System.ComponentModel.DataAnnotations;

namespace AirlineTicketingAPI.Models
{
    public class PaymentDetailsDto
    {
        [CreditCard]
        [Required]
        public string? CreditCardNumber { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Invalid expiry date format.")]
        public string? ExpiryDate { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string? CVV { get; set; }
    }
}
