namespace AutoAlquila.Domain.Vehiculos
{
    public interface IVehiculoRepositorio
    {
        Task<Vehiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
