using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class MontoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MontoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Montoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Montos.Include(m => m.Carrier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Montoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monto = await _context.Montos
                .Include(m => m.Carrier).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monto == null)
            {
                return NotFound();
            }

            return View(monto);
        }

        // GET: Montoes/Create
        public IActionResult Create()
        {
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName");
            return View();
        }

        // POST: Montoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MontoCant,CarrierId")] Monto monto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", monto.CarrierId);
            return View(monto);
        }

        // GET: Montoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monto = await _context.Montos.FindAsync(id);
            if (monto == null)
            {
                return NotFound();
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", monto.CarrierId);
            return View(monto);
        }

        // POST: Montoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MontoCant,CarrierId")] Monto monto)
        {
            if (id != monto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontoExists(monto.Id))
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
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", monto.CarrierId);
            return View(monto);
        }

        // GET: Montoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monto = await _context.Montos
                .Include(m => m.Carrier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monto == null)
            {
                return NotFound();
            }

            return View(monto);
        }

        // POST: Montoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monto = await _context.Montos.FindAsync(id);
            _context.Montos.Remove(monto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontoExists(int id)
        {
            return _context.Montos.Any(e => e.Id == id);
        }
    }
}
