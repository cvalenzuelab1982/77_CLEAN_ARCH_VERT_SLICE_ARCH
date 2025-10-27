using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Usuarios.Events
{
    public sealed record UserCreatedDomainEvent(Guid UsuarioId) : IDomainEvent;
}
