using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Aplicacion.Contratos.Persistencia
{
    public interface IUnitOfWork
    {
        Task Persistir();
        Task Reversar();
    }
}
