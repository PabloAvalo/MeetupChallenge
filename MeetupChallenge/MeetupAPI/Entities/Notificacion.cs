using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    [Table("Notificacion")]
    public class Notificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Mensaje { get; set; }

        public bool Leida { get; set; }


        [ForeignKey("UsuarioId")]

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        public int EventoId { get; set; }



    }
}
