using AutoAlquila.Domain.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlquila.Domain.Alquileres
{
    public interface IAlquilerRepository
    {
        Task<Alquiler?> GetByIdAsync(Guid id, CancellationToken cancellationToken=default);
        Task<bool> IsOverlapingAsync(Vehiculo vehiculo, RangoFechas duracion, CancellationToken cancellationToken=default);
        void Add(Alquiler alquiler);
    }
}
