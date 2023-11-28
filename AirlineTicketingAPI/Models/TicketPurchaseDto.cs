using System.ComponentModel.DataAnnotations;

namespace AirlineTicketingAPI.Models
{
    public class TicketPurchaseDto
    {
        [Required]
        public int FlightID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
