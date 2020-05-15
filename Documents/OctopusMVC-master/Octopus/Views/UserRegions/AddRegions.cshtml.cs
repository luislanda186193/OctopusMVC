using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Views.UserRegions
{
    public class AddRegionsModel : PageModel
    {
        private readonly Octopus.Data.ApplicationDbContext _context;

        public AddRegionsModel(Octopus.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UsuarioRegion> UsuarioRegion { get;set; }
        public IList<Region> Regions { get; set; }

        public async Task<dynamic> OnGetAsync()
        {
            Regions = await _context.Regions.ToListAsync();
            ViewData["regions"] = Regions;
            UsuarioRegion = await _context.UsuarioRegions
                .Include(u => u.Region)
                .Include(u => u.User).ToListAsync();
            return UsuarioRegion;
        }
    }
}
