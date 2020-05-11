using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class UsuarioRegion
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string UserId { get; set; }
        public double Comision { get; set; }
        public User User { get; set; }
        public Region Region { get; set; }
    }
}
