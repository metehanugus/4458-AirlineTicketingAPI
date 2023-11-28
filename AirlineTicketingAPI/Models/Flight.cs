using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineTicketingAPI.Models
{

    public class Flight
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? FlightNumber { get; set; }

        [Required]
        public string? Departure { get; set; }

        [Required]
        public string? Arrival { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }

        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
