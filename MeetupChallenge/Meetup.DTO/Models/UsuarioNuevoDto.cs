using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class UsuarioNuevoDto
    {
    
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato  de correo incorrecto")]
        public string Correo { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "La contraseña debe poseer mas de 8 caracteres")]
        public string Contraseña { get; set; }
        public bool IsAdmin { get; set; }
    }
}
