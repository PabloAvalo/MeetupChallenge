using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Dto.Models
{
    public class ClimaDto
    {

        [JsonProperty("dt")]
        public DateTime Fecha { get; set; }

        public string ClimaPrincipal { get; set; }
   
        public string Descripcion { get; set; }

        public string TempMax { get; set; }
    
        public string TempMin { get; set; }

        public string Humedad { get; set; }
  
        public string Noche { get; set; }

        public string Tarde { get; set; }

        public string Mañana { get; set; }

    }


}
