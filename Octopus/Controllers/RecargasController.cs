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
    public class RecargasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecargasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recargas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recargas.Include(r => r.Carrier).Include(r => r.Monto).Include(r => r.WebServDesc).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recargas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas
                .Include(r => r.Carrier)
                .Include(r => r.Monto)
                .Include(r => r.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recarga == null)
            {
                return NotFound();
            }

            return View(recarga);
        }

        // GET: Recargas/Create
        public IActionResult Create()
        {
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName");
            ViewData["MontoId"] = new SelectList(_context.Montos.AsNoTracking(), "Id", "MontoCant");
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName");
            return View();
        }

        // POST: Recargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MontoId,PhoneNumber,CarrierId,ConfirmPhone")] Recarga recarga)
        {//,DateCreated,DateResolved,StatusCode,WebServDescId,IdentityUserId
            if (ModelState.IsValid)
            {
                recarga.DateCreated = Double.Parse(DateTime.Now.Millisecond.ToString());
                recarga.StatusId = 1;
                recarga.StatusCode = 0;
                _context.Add(recarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", recarga.CarrierId);
            ViewData["MontoId"] = new SelectList(_context.Montos.AsNoTracking(), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }

        // GET: Recargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas.FindAsync(id);
            if (recarga == null)
            {
                return NotFound();
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", recarga.CarrierId);
            ViewData["MontoId"] = new SelectList(_context.Montos.AsNoTracking(), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }

        // POST: Recargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MontoId,PhoneNumber,CarrierId,DateCreated,DateResolved,StatusCode,WebServDescId,IdentityUserId")] Recarga recarga)
        {
            if (id != recarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecargaExists(recarga.Id))
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
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", recarga.CarrierId);
            ViewData["MontoId"] = new SelectList(_context.Montos.AsNoTracking(), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }

        // GET: Recargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas
                .Include(r => r.Carrier)
                .Include(r => r.Monto)
                .Include(r => r.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recarga == null)
            {
                return NotFound();
            }

            return View(recarga);
        }

        // POST: Recargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recarga = await _context.Recargas.FindAsync(id);
            _context.Recargas.Remove(recarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecargaExists(int id)
        {
            return _context.Recargas.Any(e => e.Id == id);
        }
    }
}
