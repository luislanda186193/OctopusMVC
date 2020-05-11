using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class User: IdentityUser
    {
        public string Nombre { get; set; }
        public string CreatedBy { get; set; }
        public string UserDesc
        {
            get
            {
                return string.Format("{0} - {1}", Nombre, PhoneNumber);
            }
        }
    }
}
