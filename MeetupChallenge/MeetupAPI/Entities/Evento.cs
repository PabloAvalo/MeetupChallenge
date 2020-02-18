using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength(60)]
        public string Descripcion { get; set; }

        [ForeignKey("TopicoId")]
        [Required]
        public Topico Topico { get; set; }
        public int TopicoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Ciudad { get; set; }

        public string Sucursal { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public virtual ICollection<Inscripcion> Inscriptos { get; set; } = new List<Inscripcion>();

        [ForeignKey("OrganizadorId")]
        [Required]
        public Usuario Organizador { get; set; }
        public int OrganizadorId { get; set; }

        public string Estado { get; set; }


    }
}
