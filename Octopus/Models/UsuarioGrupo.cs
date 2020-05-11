using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class UsuarioGrupo
    {
        public int Id { get; set; }
        [DisplayName("Activo")]
        public bool Status { get; set; }
        [DisplayName("Grupo")]
        public int? GrupoId { get; set; }
        [DisplayName("Usuario")]
        public string UserId { get; set; }
        public Grupo Grupo { get; set; }
        public User User { get; set; }
    }
}

 