namespace AirlineTicketingAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using AirlineTicketingAPI.Data;
    using AirlineTicketingAPI.Models;
    using Microsoft.EntityFrameworkCore;
    using AirlineTicketingAPI.Services;
    using Asp.Versioning;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenService _jwtTokenService;

        public UsersController(ApplicationDbContext context, JwtTokenService jwtTokenService)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
        }

        //POST: api/Users/BuyTicket
        public async Task<IActionResult> BuyTicket([FromBody] TicketPurchaseDetailsDto purchaseDetails)
        {
            // Validate Flight ID
            var flight = await _context.Flights.FindAsync(purchaseDetails.TicketPurchase.FlightID);
            if (flight == null)
            {
                return NotFound("Flight not found.");
            }


            // Check for available seats
            if (flight.AvailableSeats <= 0)
            {
                return BadRequest("No available seats for this flight.");
            }

            // Create a new ticket
            var ticket = new Ticket
            {
                FlightID = purchaseDetails.TicketPurchase.FlightID,
                UserID = purchaseDetails.TicketPurchase.UserID,
                BookingDate = DateTime.UtcNow
            };

            // Add the ticket to the database
            _context.Tickets.Add(ticket);

            // Update available seats
            flight.AvailableSeats--;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Ticket purchased successfully", Ticket = ticket });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userExists = await _context.Users.AnyAsync(u => u.Username == registrationDto.Username);
            if (userExists)
            {
                return BadRequest("User already exists.");
            }

            var user = new Users
            {
                Username = registrationDto.Username,
                Password = registrationDto.Password, // Consider hashing the password
                Email = registrationDto.Email,
                Role = "User" // Assign the "User" role by default
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }

    }
}
