using COMP003B.SP25.FinalProject.DomingosC.Data;
using COMP003B.SP25.FinalProject.DomingosC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.DomingosC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsApiController : ControllerBase //sub of controllerbase
    {
        private readonly ApplicationDbContext _context; //makes the content read only

        public BookingsApiController(ApplicationDbContext context)
        {
            _context = context; //Adds the content for the applicationdbcontext
        }

        [HttpGet] //gets or creates the booking model
        public async Task<ActionResult<IEnumerable<Booking>>> Get() => await _context.Bookings.ToListAsync();

        [HttpGet("{id}")] //recieves the specific Id left by the booking model
        public async Task<ActionResult<Booking>> Get(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
            return booking; //makes sure the id is present and if not then it tries again
        }

        [HttpPost] //makes sure that the booking is correct and if so gives the correct page
        public async Task<ActionResult<Booking>> Post(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //bad request = no booking
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking); //Gets the name of the booking to display
        }

        [HttpPut("{id}")] //Gives the booking the real id for use
        public async Task<IActionResult> Put(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest(); //id created and booking id must be the same
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(b => b.Id == id))
                {
                    return NotFound(); //this is simply a string to catch any of the error that might prop up
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")] //this is the method that allows deletion of entries
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound(); //if there is no specific booking selected then return notfound of course
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync(); //simply removes the booking listing

            return NoContent();
        }

    }
}
