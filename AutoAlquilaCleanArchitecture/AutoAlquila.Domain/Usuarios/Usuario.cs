using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Usuarios.Events;

namespace AutoAlquila.Domain.Usuarios
{
    public sealed class Usuario : Entity
    {
        private Usuario()
        {
            
        }

        private Usuario(Guid id, Nombre nombre, Apellido apellido, Email email) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }

        public static Usuario Create(
            Nombre nombre,
            Apellido apellido,
            Email email)
        {
            var usuario = new Usuario(Guid.NewGuid(), nombre, apellido, email);
            usuario.RaiseDomainEvent(new UserCreatedDomainEvent(usuario.Id)); //publish event
            return usuario;
        }
    }
}
