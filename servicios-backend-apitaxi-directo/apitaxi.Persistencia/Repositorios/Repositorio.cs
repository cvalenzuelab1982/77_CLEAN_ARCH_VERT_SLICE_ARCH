using ApiTaxi.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApitaxiDbContext _Context;

        public Repositorio(ApitaxiDbContext context)
        {
            _Context = context;
        }

        public Task Actualizar(T entidad)
        {
            _Context.Update(entidad);
            return Task.CompletedTask;
        }

        public Task<T> Agregar(T entidad)
        {
            _Context.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task Borrar(T entidad)
        {
            _Context.Remove(entidad);
            return Task.CompletedTask;

        }

        public async Task<T?> ObtenerPorId(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Obtenertodos()
        {
            return await _Context.Set<T>().ToListAsync();
        }
    }
}
