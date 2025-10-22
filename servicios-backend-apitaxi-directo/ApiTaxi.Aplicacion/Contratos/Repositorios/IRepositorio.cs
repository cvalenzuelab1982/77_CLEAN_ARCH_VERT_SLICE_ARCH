namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> Agregar(T entidad);
        Task Actualizar(T entidad);
        Task Borrar(T entidad);
        Task<T?> ObtenerPorId(int id);
        Task<IEnumerable<T>> Obtenertodos();
    }
}
