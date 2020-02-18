using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Dto.Models
{
    public class EventoDto
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public TopicoDto Topico { get; set; }

        public string Ciudad { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public ICollection<InscripcionNuevaDto> Inscriptos { get; set; }

        public string Sucursal { get; set; }
    }
}
