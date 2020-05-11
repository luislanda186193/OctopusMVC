using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        [DisplayName("Nombre del Grupo"), Required]
        public string GroupName { get; set; }
        [Required]
        public string OwnerId { get; set; }
    }
}
