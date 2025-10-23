using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Persistencia.Servicios.Seguridad
{
    public interface IEncripta
    {
        string Encriptar(string textoPlano);
        string Desencriptar(string textoEncriptado);
    }
}
