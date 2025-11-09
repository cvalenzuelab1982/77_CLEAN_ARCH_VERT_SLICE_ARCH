namespace AutoAlquila.Domain.Pruebas
{
    public interface IPruebaRepository
    {
        Task<List<Prueba>> ObtenerListaPruebas(CancellationToken cancellationToken);
    }
}
