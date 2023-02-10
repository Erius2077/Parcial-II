using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Configuration;
using Pasteleria.Data;
using Pasteleria.Models;


namespace Pasteleria.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ReservationRepository.GetAllAsync());
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var reservation = await _unitOfWork.ReservationRepository.GetbByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Client, "Id", "Id");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservationName,Price,RequestedDate,RequestedTime,CreatedDate,LastUpdatedDate,ClientId,ClientName,ReservationStatus")] Reservation reservation)
        {
            _unitOfWork.ReservationRepository.Add(reservation);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: reservation/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_context.Client, "Id", "Id", reservation.ClientId);
            return View(booking);
        }

        // POST: reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReservationName,Price,RequestedDate,RequestedTime,CreatedDate,LastUpdatedDate,ClientId,ClientName,ReservationStatus")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", reservation.ClientId);
            return View(reservation);
        }

        // GET: reservation/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var reservation = await _context.Booking
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return (_context.Reservation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

