using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public virtual ICollection<Configuracion> Configuracion { get; set; } = new List<Configuracion>();
        public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public bool IsAdmin { get; set; }

    }
}
