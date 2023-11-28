using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AirlineTicketingAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using AirlineTicketingAPI.Data; 
    using AirlineTicketingAPI.Models;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Asp.Versioning;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class FlightController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights(
            [FromQuery] string departure, [FromQuery] string arrival, [FromQuery] DateTime? date,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(departure))
            {
                query = query.Where(f => f.Departure != null && f.Departure.ToLower() == departure.ToLower());

            }

            if (!string.IsNullOrEmpty(arrival))
            {
                query = query.Where(f => f.Arrival.ToLower() == arrival.ToLower());
            }

            if (date.HasValue)
            {
                query = query.Where(f => f.Date != null && f.Date.Date == date.Value.Date);
            }



            var totalFlights = await query.CountAsync();
            var flights = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new
            {
                Total = totalFlights,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Flights = flights
            };

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateFlight([FromBody] Flight flight)
        {
            if (flight == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlight), new { id = flight.ID }, flight);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != flight.ID || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool FlightExists(int id)
        {

            return _context.Flights.Any(e => e.ID == id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
