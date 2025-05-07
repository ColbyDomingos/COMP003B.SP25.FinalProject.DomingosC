using COMP003B.SP25.FinalProject.DomingosC.Data;
using COMP003B.SP25.FinalProject.DomingosC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.DomingosC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //cannot be changed on this code string

        public BookingsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //this setup is for the bookings part and below it is for the mechanics
        [HttpGet("bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings() => await _context.Bookings.ToListAsync();

        [HttpGet("bookings/{id}")] //gets the id for the booking created
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound(); //if no booking then bad
            return booking;
        }

        [HttpPost("bookings")] //starts the creation process for the booking
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //this was throwig so many errors I wanted to rip my hair out
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking); //creates the booking
        }

        [HttpPut("bookings/{id}")] //puts the new booking in the database
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id) return BadRequest();
            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(b => b.Id == id)) return NotFound(); //if no bookings were found then declare not found
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("bookings/{id}")] //allows for the deletion of bookings
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
            //finds the booking and deletes it
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //mechanics was throwing a lot of errors so I decided to merge the bookind and mechanics api controllers
        //i pretty much just copied and pasted the sections from the booking strings
        [HttpGet("mechanics")]
        public async Task<ActionResult<IEnumerable<Mechanic>>> GetMechanics() => await _context.Mechanics.ToListAsync();

        [HttpGet("mechanics/{id}")]
        public async Task<ActionResult<Mechanic>> GetMechanic(int id)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null) return NotFound(); //recieves the id for the mechanic and makes sure it isnt null
            return mechanic;
        }

        [HttpPost("mechanics")]
        public async Task<ActionResult<Mechanic>> PostMechanic(Mechanic mechanic)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Mechanics.Add(mechanic); //allows for the mechanic to be created 
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMechanic), new { id = mechanic.Id }, mechanic);
        }

        [HttpPut("mechanics/{id}")] //creates the mechanic with the specified id
        public async Task<IActionResult> PutMechanic(int id, Mechanic mechanic)
        {
            if (id != mechanic.Id) return BadRequest();
            _context.Entry(mechanic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) //this helps with the countless errors I got
            {
                if (!_context.Mechanics.Any(m => m.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("mechanics/{id}")] //deletion for the mechanics Id
        public async Task<IActionResult> DeleteMechanic(int id)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null) return NotFound();

            _context.Mechanics.Remove(mechanic);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
