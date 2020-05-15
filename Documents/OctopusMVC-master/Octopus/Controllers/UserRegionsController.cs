using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class UserRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "UserData";
        public UserRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserRegions
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString(SessionKeyName);
            if (userId != null) {
                var applicationDbContext = _context.UsuarioRegions.Where(s=>s.UserId == userId).Include(u => u.Region).AsNoTracking();
                /*var regions = _context.Regions.ToList();
                ViewBag.regions = regions;*/
                var regions = _context.Regions.Include(s=>s.Carrier);
                ViewBag.regions = regions;
                ViewBag.userId = userId;
                //ViewData["RegionId"] = new SelectList(regions, "Id", "RegionName");
                //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
                return View(await applicationDbContext.ToListAsync());
            }
            return View();
        }

        // GET: UserRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRegion = await _context.UsuarioRegions
                .Include(u => u.Region)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioRegion == null)
            {
                return NotFound();
            }

            return View(usuarioRegion);
        }

        // GET: UserRegions/Create
        public IActionResult Create()
        {
            ViewBag.editar = false;
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        public IActionResult CreateUserRegions(string userId)
        {
            HttpContext.Session.SetString(SessionKeyName, userId);

            return RedirectToAction(nameof(Index));
        }

        // POST: UserRegions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegionId,UserId,Comision,Status,Region")] UsuarioRegion usuarioRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioRegion);
                await _context.SaveChangesAsync();
                var userRegion = await _context.UsuarioRegions
                    .Where(s => s.RegionId == usuarioRegion.RegionId
                    && s.UserId == usuarioRegion.UserId).Include(p => p.Region).ThenInclude(c => c.Carrier)
                    .FirstOrDefaultAsync();
                ViewBag.successMsg = "Se asigno Correctamente el " + userRegion.Comision
                + "% de comisión a la " + userRegion.Region.RegionName+" de "+userRegion.Region.Carrier.CarrierName;
                ViewBag.editar = true;
                return View(userRegion);
                //return RedirectToAction(nameof(Index));
            }
            ViewBag.editar = false;
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", usuarioRegion.RegionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usuarioRegion.UserId);
            return View(usuarioRegion);
        }

        // GET: UserRegions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRegion = await _context.UsuarioRegions.FindAsync(id);
            if (usuarioRegion == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", usuarioRegion.RegionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usuarioRegion.UserId);
            return View(usuarioRegion);
        }

        // POST: UserRegions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegionId,UserId,Comision,Status")] UsuarioRegion usuarioRegion)
        {
            if (id != usuarioRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioRegionExists(usuarioRegion.Id))
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
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", usuarioRegion.RegionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usuarioRegion.UserId);
            return View(usuarioRegion);
        }

        // GET: UserRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRegion = await _context.UsuarioRegions
                .Include(u => u.Region)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioRegion == null)
            {
                return NotFound();
            }

            return View(usuarioRegion);
        }

        // POST: UserRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioRegion = await _context.UsuarioRegions.FindAsync(id);
            _context.UsuarioRegions.Remove(usuarioRegion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioRegionExists(int id)
        {
            return _context.UsuarioRegions.Any(e => e.Id == id);
        }
    }
}
