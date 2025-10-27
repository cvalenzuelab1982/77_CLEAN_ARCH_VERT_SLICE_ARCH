namespace AutoAlquila.Domain.Usuarios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(Usuario usuario);
    }
}
