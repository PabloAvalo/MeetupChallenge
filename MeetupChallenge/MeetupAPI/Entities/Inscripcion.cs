using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    [Table("Inscripcion")]
    public class Inscripcion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("EventoId")]
        [Required]

        public Evento Evento { get; set; }
        public int EventoId { get; set; }

        [ForeignKey("UsuarioId")]
        [Required]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public bool CheckIn { get; set; }

    }
}
