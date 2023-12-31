﻿using System.Net.Sockets;

namespace AirlineTicketingAPI.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }

}
