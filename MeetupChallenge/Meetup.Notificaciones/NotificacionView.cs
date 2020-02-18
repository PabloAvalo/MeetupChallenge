using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Notificaciones
{
    public class NotificacionView
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Mensaje { get; set; }

        public bool Leida { get; set; }

        public int EventoId { get; set; }
    }
}
