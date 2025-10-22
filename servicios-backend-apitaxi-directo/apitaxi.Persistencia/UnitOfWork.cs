using ApiTaxi.Aplicacion.Contratos.Persistencia;

namespace ApiTaxi.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApitaxiDbContext _Context;

        public UnitOfWork(ApitaxiDbContext context)
        {
            _Context = context;
        }

        public async Task Persistir()
        {
            await _Context.SaveChangesAsync();
        }

        public Task Reversar()
        {
            return Task.CompletedTask;
        }
    }
}
