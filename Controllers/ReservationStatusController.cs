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
    public class ReservationStatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationStatusController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: ReservationStatus
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ReservationRepository.GetAllAsync());
        }

        // GET: ReservationStatus/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var reservationStatus = await _unitOfWork.ReservationStatusRepository.GetbByIdAsync(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }

            return View(reservationStatus);
        }

        // GET: ReservationStatus/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
            return View();
        }

        // POST: ReservationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservationName,Price,RequestedDate,RequestedTime,CreatedDate,LastUpdatedDate,ClientId,ClientName,ReservationStatus")] ReservationStatus reservationStatus)
        {
            _unitOfWork.ReservationRepository.Add(reservationStatus);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: reservationStatus/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.ReservationStatus == null)
            {
                return NotFound();
            }

            var reservationStatus = await _context.ReservationStatus.FindAsync(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }
            ViewData["ReservationStatusId"] = new SelectList(_context.Client, "Id", "Id", reservation.ClientId);
            return View(bookingStatus);
        }

        // POST: reservationStatus/Edit/5
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
                    _context.Update(reservationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservationStatus.Id))
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
            ViewData["ClientId"] = new SelectList(_context.User, "Id", "Id", reservationStatus.ClientId);
            return View(reservationStatus);
        }

        // GET: reservationStatus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.BookingStatus == null)
            {
                return NotFound();
            }

            var reservationStatus = await _context.BookingStatus
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationStatus == null)
            {
                return NotFound();
            }

            return View(reservationStatus);
        }

        // POST: reservationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservationStatus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ReservationStatus'  is null.");
            }
            var reservationStatus = await _context.ReservationStatus.FindAsync(id);
            if (reservationStatus != null)
            {
                _context.Reservation.Remove(reservationStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationStatusExists(int id)
        {
            return (_context.ReservationStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
