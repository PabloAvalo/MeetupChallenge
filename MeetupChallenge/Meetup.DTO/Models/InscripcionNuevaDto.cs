using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class InscripcionNuevaDto
    {

        [Required]
        public int EventoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

    }
}
