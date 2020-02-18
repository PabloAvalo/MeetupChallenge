using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class InscripcionDto
    {
      
        public int EventoId { get; set; }

        public int UsuarioId { get; set; }
        public bool CheckIn { get; set; }

  
    }
}
