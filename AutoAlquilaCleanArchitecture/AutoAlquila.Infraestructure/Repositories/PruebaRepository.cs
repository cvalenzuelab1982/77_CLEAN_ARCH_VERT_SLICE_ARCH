using AutoAlquila.Domain.Pruebas;
using Microsoft.EntityFrameworkCore;

namespace AutoAlquila.Infraestructure.Repositories
{
    public sealed class PruebaRepository : IPruebaRepository
    {
        private readonly ApplicationDbContext DbContext;

        public PruebaRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<List<Prueba>> ObtenerListaPruebas(CancellationToken cancellationToken)
        {
            return DbContext.Set<Prueba>().ToListAsync();
        }
    }
}
