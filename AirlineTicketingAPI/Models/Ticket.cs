using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineTicketingAPI.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Flight")]
        public int FlightID { get; set; }
        public virtual Flight? Flight { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual Users? User { get; set; }

        public DateTime BookingDate { get; set; }
    }
}

