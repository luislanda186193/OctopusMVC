using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Lada
    {
        public int Id { get; set; }
        [DisplayName("Código Lada"), MaxLength(10)]
        public string LadaName { get; set; }
        [DisplayName("Región")]
        public int RegionId { get; set; }

        public Region Region { get; set; }

      

    }
}
