using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Log
    {
        public int Id { get; set; }
        [DisplayName("Monto")]
        public string LogDesc { get; set; }
        public int RecargaId  { get; set; }

        public Recarga Recarga { get; set; }
       
    }
}
