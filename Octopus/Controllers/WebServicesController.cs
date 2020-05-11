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
    public class WebServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WebServices.Include(w => w.WebServDesc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WebServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webService = await _context.WebServices
                .Include(w => w.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webService == null)
            {
                return NotFound();
            }

            return View(webService);
        }

        // GET: WebServices/Create
        public IActionResult Create()
        {
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs, "Id", "WebServiceName");
            return View();
        }

        // POST: WebServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order,Status,WebServDescId")] WebService webService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs, "Id", "WebServiceName", webService.WebServDescId);
            return View(webService);
        }

        // GET: WebServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webService = await _context.WebServices.FindAsync(id);
            if (webService == null)
            {
                return NotFound();
            }
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs, "Id", "WebServiceName", webService.WebServDescId);
            return View(webService);
        }

        // POST: WebServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order,Status,WebServDescId")] WebService webService)
        {
            if (id != webService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebServiceExists(webService.Id))
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
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs, "Id", "WebServiceName", webService.WebServDescId);
            return View(webService);
        }

        // GET: WebServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webService = await _context.WebServices
                .Include(w => w.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webService == null)
            {
                return NotFound();
            }

            return View(webService);
        }

        // POST: WebServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webService = await _context.WebServices.FindAsync(id);
            _context.WebServices.Remove(webService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebServiceExists(int id)
        {
            return _context.WebServices.Any(e => e.Id == id);
        }
    }
}
