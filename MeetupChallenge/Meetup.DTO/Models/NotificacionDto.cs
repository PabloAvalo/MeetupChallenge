using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class NotificacionDto
    {

        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Mensaje { get; set; }

        public bool Leida { get; set; }
   
        public EventoDto Evento { get; set; }

    }
}
