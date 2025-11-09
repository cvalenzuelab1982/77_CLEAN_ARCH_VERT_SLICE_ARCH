using AutoAlquila.Domain.Usuarios;

namespace AutoAlquila.Infraestructure.Repositories
{
    internal sealed class UsuarioRepository : Repository<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
