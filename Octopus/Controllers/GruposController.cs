using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Octopus.Controllers
{
    public class GruposController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        public const string SessionKeyName = "UserData";

        public GruposController(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
            


        }
        private string getCurrentUserId(string attr) {

            switch (attr) {
                case "id":
                    return  _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";
                   
                case "name":
                    return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.Name) : "";
                   
                default:
                    break;

            }
            return "";
        }
        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var userId = getCurrentUserId("id");
            var listGroup = await _context.Grupos.Where(s => s.OwnerId == userId).ToListAsync();
            return View(listGroup);
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }
        public IActionResult CrearUnGrupo(string message = "")
        {
            HttpContext.Session.SetString(SessionKeyName, message);
           
            return RedirectToAction(nameof(Create));
          //  return View();
        }
        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewBag.message = HttpContext.Session.GetString("UserData"); 
            // ViewBag.message = message;
            ViewBag.userId = getCurrentUserId("id");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName,OwnerId")] Grupo grupo)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.userId = getCurrentUserId("id");
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.userName = getCurrentUserId("name");
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName,OwnerId")] Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                  ViewBag.userName = getCurrentUserId("name");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.userName = getCurrentUserId("name");
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.Id == id);
        }
    }
}
