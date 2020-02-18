using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Entities
{
    [Table("Topico")]
    public class Topico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

    }
}
