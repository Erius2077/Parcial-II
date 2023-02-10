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
    public class CalendaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CalendaryController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Calendary
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.CalendaryRepository.GetAllAsync());
        }

        // GET: Calendary/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _unitOfWork.CalendaryRepository.GetbByIdAsync(id);
            if (calendary == null)
            {
                return NotFound();
            }

            return View(calendary);
        }

        // GET: Calendary/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
            return View();
        }

        // POST: Calendary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ClientId")] Calendary calendary)
        {
            _unitOfWork.CalendaryRepository.Add(calendary);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: Calendary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _context.Calendary.FindAsync(id);
            if (calendary == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", Calendary.ClientId);
            return View(calendary);
        }

        // POST: Calendary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ClientId")] Calendary calendary)
        {
            if (id != calendary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendaryExists(calendary.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", schedule.ClientId);
            return View(calendary);
        }

        // GET: Calendary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _context.Calendary
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendary == null)
            {
                return NotFound();
            }

            return View(calendary);
        }

        // POST: Calendary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendary == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calendary'  is null.");
            }

            _unitOfWork.CalendaryRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendaryExists(int id)
        {
            return _unitOfWork.CalendaryRepository.GetbByIdAsync(id) != null;
        }
    }
}