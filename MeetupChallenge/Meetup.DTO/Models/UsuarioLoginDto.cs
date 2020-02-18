using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage ="Debe Ingresar el correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage ="Debe Ingresar Contraseña")]
        public string Contraseña { get; set; }
    }
}
