using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class ConfiguracionNuevaDto

    {

        /// <summary>
        /// Clave que representa el tipo de configuracion a agregar
        /// </summary>
        [Required(ErrorMessage ="Debe enviar la clave de la configuracion")]
        public string Key { get; set; }
        /// <summary>
        /// Valor de la configuracion
        /// </summary>
        [Required(ErrorMessage ="Debe enviar el valor de la configuracion")]
        public string Value { get; set; }
        [Required(ErrorMessage ="Se requiere el id del usuario")]
        public int UsuarioId { get; set; }
    }
}
