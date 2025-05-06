using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.DomingosC.Data;
using COMP003B.SP25.FinalProject.DomingosC.Models;

namespace COMP003B.SP25.FinalProject.DomingosC.Controllers
{
    public class BookingMechanicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingMechanicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingMechanics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookingMechanic.Include(b => b.Booking).Include(b => b.Mechanic);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookingMechanics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingMechanic = await _context.BookingMechanic
                .Include(b => b.Booking)
                .Include(b => b.Mechanic)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookingMechanic == null)
            {
                return NotFound();
            }

            return View(bookingMechanic);
        }

        // GET: BookingMechanics/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "Id", "Id");
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "Id");
            return View();
        }

        // POST: BookingMechanics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,MechanicId")] BookingMechanic bookingMechanic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingMechanic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "Id", "Id", bookingMechanic.BookingId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "Id", bookingMechanic.MechanicId);
            return View(bookingMechanic);
        }

        // GET: BookingMechanics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingMechanic = await _context.BookingMechanic.FindAsync(id);
            if (bookingMechanic == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "Id", "Id", bookingMechanic.BookingId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "Id", bookingMechanic.MechanicId);
            return View(bookingMechanic);
        }

        // POST: BookingMechanics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,MechanicId")] BookingMechanic bookingMechanic)
        {
            if (id != bookingMechanic.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingMechanic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingMechanicExists(bookingMechanic.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "Id", "Id", bookingMechanic.BookingId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "Id", bookingMechanic.MechanicId);
            return View(bookingMechanic);
        }

        // GET: BookingMechanics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingMechanic = await _context.BookingMechanic
                .Include(b => b.Booking)
                .Include(b => b.Mechanic)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookingMechanic == null)
            {
                return NotFound();
            }

            return View(bookingMechanic);
        }

        // POST: BookingMechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingMechanic = await _context.BookingMechanic.FindAsync(id);
            if (bookingMechanic != null)
            {
                _context.BookingMechanic.Remove(bookingMechanic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingMechanicExists(int id)
        {
            return _context.BookingMechanic.Any(e => e.BookingId == id);
        }
    }
}
