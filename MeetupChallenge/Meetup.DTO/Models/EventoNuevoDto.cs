using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class EventoNuevoDto
    {



        [Required(ErrorMessage ="You must provide a name")]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength(60)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Id del topico del que se trata la meeting
        /// </summary>
        [Required]
        public int TopicoId { get; set; }
   
        /// <summary>
        /// Ciudad en la que se desarrolla la meeting
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Ciudad { get; set; }
        /// <summary>
        /// Fecha en la que se realiza la meeting
        /// </summary>

        [Required]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// id del usuario que crea la meeting
        /// </summary>

        [Required]
        public int OrganizadorId { get; set; }

        public string Sucursal { get; set; }
    }
}
