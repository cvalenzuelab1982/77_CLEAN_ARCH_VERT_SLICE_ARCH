using AutoAlquila.Domain.Vehiculos;

namespace AutoAlquila.Infraestructure.Repositories
{
    internal sealed class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepositorio
    {
        public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
