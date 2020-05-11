using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Migrations;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class WebServRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebServRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebServRegions
        public async Task<IActionResult> Index()
        {
            List<Carrier> carriers = await _context.Carriers.ToListAsync();
            List<WebService> webServices = await _context.WebServices.ToListAsync();
            List<Region> regions = await _context.Regions.ToListAsync();

            List<WebServRegion>  webServRegions  = await _context.WebServRegions.Include(x=>x.Region).ToListAsync();

            var wsSelectList = new SelectList(webServices, nameof(WebService.Id), "");//nameof(WebService.WebServiceName));
            var regionSelectList = new SelectList(regions, nameof(Region.Id), nameof(Region.RegionName));
            ViewBag.regions = regionSelectList;
            ViewBag.webServices = wsSelectList;

            return View(webServRegions);
        }

        // GET: WebServRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServRegion = await _context.WebServRegions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServRegion == null)
            {
                return NotFound();
            }

            return View(webServRegion);
        }

        // GET: WebServRegions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebServRegions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] WebServRegion webServRegion)
        {
            if (ModelState.IsValid)
            {
                webServRegion.Region = new Region
                {
                    Id = 1,
                    RegionName = "Region 1"
                };
             
                //webServRegion.Id = null;
                _context.Add(webServRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webServRegion);
        }

        // GET: WebServRegions/Edit/5
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
            return View(webServRegion);
        }

        // POST: WebServRegions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] WebServRegion webServRegion)
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
            return View(webServRegion);
        }

        // GET: WebServRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServRegion = await _context.WebServRegions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServRegion == null)
            {
                return NotFound();
            }

            return View(webServRegion);
        }

        // POST: WebServRegions/Delete/5
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
