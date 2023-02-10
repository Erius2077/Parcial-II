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
    public class CakeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CakeController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Cakes
        public async Task<IActionResult> Index()
        {
            return _context.Treatment != null ?
                        View(await _context.Treatment.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cake'  is null.");
        }

        // GET: Cake/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // GET: Cake/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Image")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cake);
        }

        // GET: Cake/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            return View(treatment);
        }

        // POST: Cake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Description,Image")] Treatment treatment)
        {
            if (id != cake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeExists(cake.Id))
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
            return View(cake);
        }

        // GET: Cake/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // POST: Cake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cake == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cake'  is null.");
            }
            var cake = await _context.Cake.FindAsync(id);
            if (cake != null)
            {
                _context.Cake.Remove(treatment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeExists(string id)
        {
            return (_context.Cake?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
