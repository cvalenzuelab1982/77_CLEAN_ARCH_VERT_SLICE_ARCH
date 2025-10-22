using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioServicios : IRepositorioServicios
    {
        public RepositorioServicios()
        {
            
        }

        public Task Actualizar(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Servicio> Agregar(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public Task Borrar(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Servicio?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Servicio>> Obtenertodos()
        {
            throw new NotImplementedException();
        }
    }
}
