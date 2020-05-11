using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Recarga
    {
        public int Id { get; set; }
        [DisplayName("Monto")]
        public int MontoId { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número debe contener 10 dígitos")]
        
        [Display(Name = "Teléfono")]
        public double PhoneNumber { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número debe contener 10 dígitos")]
        
        [Display(Name = "Confirmar Teléfono")]
        [Compare("PhoneNumber", ErrorMessage = "Los números no coinciden.")]
        public double ConfirmPhone { get; set; }
        [DisplayName("Compañía")]
        public int CarrierId { get; set; }
        [DisplayName("Fecha Creación")]
        public double DateCreated { get; set; }
        [DisplayName("Fecha Resolución")]
        public double? DateResolved { get; set; }
        [DisplayName("Acuse")]
        public int StatusCode { get; set; }
        [DisplayName("Estado")]
        public int StatusId { get; set; }
        [DisplayName("Servicio Web")]
        public int? WebServDescId { get; set; }
        [DisplayName("Usuario")]
        public string UserId { get; set; }
        public Monto Monto { get; set; }
        public Carrier Carrier { get; set; }
        public WebServDesc WebServDesc { get; set; }

        public Status Status { get; set; }

       public User User { get; set; }
    }
}
