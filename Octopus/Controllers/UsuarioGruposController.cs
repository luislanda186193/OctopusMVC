using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Microsoft.AspNetCore.Http;

namespace Octopus.Controllers
{
    public class UsuarioGruposController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        public const string SessionKeyName = "UserData";

        public UsuarioGruposController(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
        }
        private string getCurrentUserId(string attr)
        {

            switch (attr)
            {
                case "id":
                    return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";

                case "name":
                    return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.Name) : "";

                default:
                    break;

            }
            return "";
        }
        // GET: UsuarioGrupos
        public async Task<IActionResult> Index()
        {
          
            ViewBag.message = HttpContext.Session.GetString(SessionKeyName);
            HttpContext.Session.Remove(SessionKeyName);
            var grupo = _context.Grupos
                .Where(s => s.OwnerId == getCurrentUserId("id")).AsNoTracking().FirstOrDefault();
            if (grupo != null) {
                var applicationDbContext = _context.UsuarioGrupos.Where(s=>s.GrupoId == grupo.Id).Include(u => u.User)
                    .Include(s => s.Grupo).AsNoTracking();
               
                return View(await applicationDbContext.ToListAsync());
            }
            
            return View();
        }

        // GET: UsuarioGrupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos
                .Include(u => u.User).Where(s=>s.User.CreatedBy == getCurrentUserId("id") || s.User.CreatedBy == "self")
                .Include(s => s.Grupo).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Create
        public IActionResult Create()
        {
            List<Grupo> grupos = _context.Grupos.Where(S => S.OwnerId == getCurrentUserId("id")).ToList();
            if (grupos.Count() < 1)
            {
                return RedirectToAction("CrearUnGrupo", "Grupos", new { message = "Primero crea un grupo" });
            }
            ViewData["GrupoId"] = new SelectList(grupos, "Id", "GroupName");
            ViewData["IdentityUserId"] = new SelectList(_context.Users.Where(s => s.CreatedBy == getCurrentUserId("id") || s.CreatedBy == "self"), "Id", "UserDesc");
            return View();
        }

        // POST: UsuarioGrupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,GrupoId,UserId")] UsuarioGrupo usuarioGrupo)
        {
            if (ModelState.IsValid)
            {
                var registerExist = _context.UsuarioGrupos
                    .Where(S => S.GrupoId == usuarioGrupo.GrupoId 
                    && S.UserId == usuarioGrupo.UserId).AsNoTracking().FirstOrDefault();
                if (registerExist == null)
                {
                   
                    _context.Add(usuarioGrupo);
                    await _context.SaveChangesAsync();
                }
                else {
                    HttpContext.Session.SetString(SessionKeyName, "El usuario ya se encuentra en el grupo");
                }
               
                return RedirectToAction(nameof(Index));
            }
            List<Grupo> grupos = _context.Grupos.Where(S => S.OwnerId == getCurrentUserId("id")).ToList();
            if (grupos.Count() < 1) {
                RedirectToAction("Create", "Groups",new { message = "Primero crea un grupo"});
            }
            ViewData["GrupoId"] = new SelectList(grupos, "Id", "GroupName");
            ViewData["IdentityUserId"] = new SelectList(_context.Users.Where(s => s.CreatedBy == getCurrentUserId("id") || s.CreatedBy == "self"), "Id", "UserDesc", usuarioGrupo.UserId);
            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos.FindAsync(id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos.Where(S => S.OwnerId == getCurrentUserId("id")), "Id", "GroupName");
            ViewData["IdentityUserId"] = new SelectList(_context.Users.Where(s => s.CreatedBy == getCurrentUserId("id") || s.CreatedBy == "self"), "Id", "UserName", usuarioGrupo.UserId);
            return View(usuarioGrupo);
        }

        // POST: UsuarioGrupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,GrupoId,IdentityUserId")] UsuarioGrupo usuarioGrupo)
        {
            if (id != usuarioGrupo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioGrupoExists(usuarioGrupo.Id))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos.Where(S => S.OwnerId == getCurrentUserId("id")), "Id", "GroupName");
            ViewData["IdentityUserId"] = new SelectList(_context.Users.Where(s => s.CreatedBy == getCurrentUserId("id") || s.CreatedBy == "self"), "Id", "UserName", usuarioGrupo.UserId);
            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos
                .Include(u => u.User)
                .Include(s => s.Grupo).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioGrupo);
        }

        // POST: UsuarioGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioGrupo = await _context.UsuarioGrupos.FindAsync(id);
            _context.UsuarioGrupos.Remove(usuarioGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioGrupoExists(int id)
        {
            return _context.UsuarioGrupos.Any(e => e.Id == id);
        }
    }
}
