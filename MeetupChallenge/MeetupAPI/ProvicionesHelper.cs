using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api
{
    public class ProvicionesHelper
    {

        private const int CANTIDAD_X_PACK = 6;
        public static int CantidadDeBirras(int cantidadInscriptos, double temperatura) {

            double multiplicador = 1;

            if (temperatura < 20)
                multiplicador = 0.75;
            else if (temperatura > 24)
                multiplicador = 2;

            return (int)Math.Ceiling(cantidadInscriptos * multiplicador / CANTIDAD_X_PACK);
            
        
        }
    }
}
