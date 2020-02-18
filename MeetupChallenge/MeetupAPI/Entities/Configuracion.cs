using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    public class Configuracion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }


    
    }
}
