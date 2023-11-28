namespace AirlineTicketingAPI.Models
{
    public class TicketPurchaseDetailsDto
    {
        public TicketPurchaseDto? TicketPurchase { get; set; }
        public PaymentDetailsDto? PaymentDetails { get; set; }
    }

}
