using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;

namespace AutoAlquila.Infraestructure.Repositories
{
    internal sealed class AlquilerRepository : Repository<Alquiler>, IAlquilerRepository
    {
        private static readonly AlquilerStatus[] ActiveAlquilerStatus =
        {
            AlquilerStatus.Reservado,
            AlquilerStatus.Confirmado,
            AlquilerStatus.Completado
        };

        public AlquilerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlapingAsync(Vehiculo vehiculo, RangoFechas duracion, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Alquiler>().AnyAsync(
                x =>
                    x.VehiculoId == vehiculo.Id &&
                    x.Duracion!.Inicio <= duracion.Fin &&
                    x.Duracion.Fin >= duracion.Inicio &&
                    ActiveAlquilerStatus.Contains(x.Status),
                    cancellationToken
                );
        }
    }
}
