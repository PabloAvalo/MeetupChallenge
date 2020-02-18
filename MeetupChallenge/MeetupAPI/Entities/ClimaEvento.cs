using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    public class ClimaEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("EventoId")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public string ClimaPrincipal { get; set; }

        public string Descripcion { get; set; }

        public string TempMax { get; set; }

        public string TempMin { get; set; }

        public string Humedad { get; set; }

        public string Noche { get; set; }

        public string Tarde { get; set; }

        public string Mañana { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
