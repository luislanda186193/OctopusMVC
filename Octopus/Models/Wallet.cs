using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public double SaldoTAE { get; set; }
        public double SaldoNormal { get; set; }
        public string IdentityUserId { get; set; }
        public double? ComisionTAE { get; set; }
       // public IdentityUser IdentityUser { get; set; }
    }
}
