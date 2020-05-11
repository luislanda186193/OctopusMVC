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
    public class WebServDescsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebServDescsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebServDescs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebServDescs.ToListAsync());
        }

        // GET: WebServDescs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServDesc = await _context.WebServDescs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServDesc == null)
            {
                return NotFound();
            }

            return View(webServDesc);
        }

        // GET: WebServDescs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebServDescs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WebServiceName,URL")] WebServDesc webServDesc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webServDesc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webServDesc);
        }

        // GET: WebServDescs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServDesc = await _context.WebServDescs.FindAsync(id);
            if (webServDesc == null)
            {
                return NotFound();
            }
            return View(webServDesc);
        }

        // POST: WebServDescs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WebServiceName,URL")] WebServDesc webServDesc)
        {
            if (id != webServDesc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webServDesc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebServDescExists(webServDesc.Id))
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
            return View(webServDesc);
        }

        // GET: WebServDescs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webServDesc = await _context.WebServDescs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webServDesc == null)
            {
                return NotFound();
            }

            return View(webServDesc);
        }

        // POST: WebServDescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webServDesc = await _context.WebServDescs.FindAsync(id);
            _context.WebServDescs.Remove(webServDesc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebServDescExists(int id)
        {
            return _context.WebServDescs.Any(e => e.Id == id);
        }
    }
}
