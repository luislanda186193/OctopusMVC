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
    public class WebServRegions1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebServRegions1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebServRegions1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WebServRegions.Include(w => w.Region).ThenInclude(w=>w.Carrier).Include(z => z.WebService).ThenInclude(z => z.WebServDesc).AsNoTracking().OrderBy(s=>s.Region.Id);
            var webService = await applicationDbContext.ToListAsync();
            return View(webService);
        }

        // GET: WebServRegions1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServRegion = await _context.WebServRegions
                .Include(w => w.Region)
                .Include(w => w.WebService).ThenInclude(z=>z.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServRegion == null)
            {
                return NotFound();
            }

            return View(webServRegion);
        }

        // GET: WebServRegions1/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName");
             ViewData["WebServiceId"] = new SelectList(_context.WebServices.Include(w => w.WebServDesc), "Id", "WSDesc");

            //ViewData["WebServiceId"] = new SelectList(_context.WebServices, "Id", "Id");
            return View();
        }

        // POST: WebServRegions1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WebServiceId,RegionId")] WebServRegion webServRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webServRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "RegionName", webServRegion.RegionId);
            ViewData["WebServiceId"] = new SelectList(_context.WebServices.Include(w => w.WebServDesc).AsNoTracking(), "Id", "WSDesc", webServRegion.WebServiceId);
            return View(webServRegion);
        }

        // GET: WebServRegions1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServRegion = await _context.WebServRegions.FindAsync(id);
            if (webServRegion == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions.Where(i=>i.Id == webServRegion.RegionId).AsNoTracking(), "Id", "RegionName", webServRegion.RegionId);
            ViewData["WebServiceId"] = new SelectList(_context.WebServices.Include(w => w.WebServDesc).AsNoTracking(), "Id", "WSDesc", webServRegion.WebServiceId);
            return View(webServRegion);
        }

        // POST: WebServRegions1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WebServiceId,RegionId")] WebServRegion webServRegion)
        {
            if (id != webServRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webServRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebServRegionExists(webServRegion.Id))
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
            ViewData["RegionId"] = new SelectList(_context.Regions.Where(i => i.Id == webServRegion.RegionId).AsNoTracking(), "Id", "RegionName", webServRegion.RegionId);
            ViewData["WebServiceId"] = new SelectList(_context.WebServices.Include(w => w.WebServDesc).AsNoTracking(), "Id", "WSDesc", webServRegion.WebServiceId);
            return View(webServRegion);
        }

        // GET: WebServRegions1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServRegion = await _context.WebServRegions
                .Include(w => w.Region)
                .Include(w => w.WebService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServRegion == null)
            {
                return NotFound();
            }

            return View(webServRegion);
        }

        // POST: WebServRegions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webServRegion = await _context.WebServRegions.FindAsync(id);
            _context.WebServRegions.Remove(webServRegion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebServRegionExists(int id)
        {
            return _context.WebServRegions.Any(e => e.Id == id);
        }
    }
}
