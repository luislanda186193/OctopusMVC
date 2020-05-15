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
    public class CarterasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "UserData";

        public CarterasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carteras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carteras.ToListAsync());
        }

        // GET: Carteras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartera == null)
            {
                return NotFound();
            }

            return View(cartera);
        }
        public async Task<IActionResult> CrearUnWallet(string userId = "")
        {
            HttpContext.Session.SetString(SessionKeyName, userId);
            if (userId != null)
            {
                var userWallet = await _context.Users.Include(s=>s.Cartera).FirstOrDefaultAsync(s=>s.Id == userId);
                if (userWallet.Cartera != null)
                {
                    return RedirectToAction(nameof(Edit), new { userWallet.Cartera.Id });
                }
                else
                {
                    return RedirectToAction(nameof(Create), new { userWallet.Id });
                }

            }
            return RedirectToAction(nameof(Create));
            //  return View();
        }
        // GET: Carteras/Create
        public IActionResult Create(string id)
        {
            ViewBag.userId = id;
            return View();
        }

        // POST: Carteras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaldoTAE,SaldoNormal,ComisionTAE,UserId")] Cartera cartera)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(s => s.Id == cartera.UserId);
                user.Cartera = cartera;

                _context.Entry(user).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Index","Users");
            }
            return View(cartera);
        }

        // GET: Carteras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras.FindAsync(id);
            if (cartera == null)
            {
                return NotFound();
            }
            return View(cartera);
        }

        // POST: Carteras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaldoTAE,SaldoNormal,ComisionTAE")] Cartera cartera)
        {
            if (id != cartera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteraExists(cartera.Id))
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
            return View(cartera);
        }

        // GET: Carteras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartera == null)
            {
                return NotFound();
            }

            return View(cartera);
        }

        // POST: Carteras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartera = await _context.Carteras.FindAsync(id);
            _context.Carteras.Remove(cartera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteraExists(int id)
        {
            return _context.Carteras.Any(e => e.Id == id);
        }
    }
}
