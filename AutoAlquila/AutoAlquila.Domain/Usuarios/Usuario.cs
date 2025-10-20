using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Usuarios.Events;

namespace AutoAlquila.Domain.Usuarios
{
    public sealed class Usuario : Entity
    {
        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }

        private Usuario(
            Guid id,
            Nombre nombre,
            Apellido apellido,
            Email email
        ) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public static Usuario Create(Nombre nombre, Apellido apellido, Email email)
        {
            var usuario = new Usuario(Guid.NewGuid(), nombre, apellido, email);
            usuario.RaiseDomainEvent(new UsuarioCreatedDomainEvent(usuario.Id));
            return usuario;
        }
    }
}
