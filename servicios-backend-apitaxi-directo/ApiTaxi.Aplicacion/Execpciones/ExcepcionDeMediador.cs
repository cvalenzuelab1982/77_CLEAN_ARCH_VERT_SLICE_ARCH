using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Aplicacion.Execpciones
{
    public class ExcepcionDeMediador : Exception
    {
        public ExcepcionDeMediador(string mensaje) : base(mensaje)
        {
            
        }
    }
}
