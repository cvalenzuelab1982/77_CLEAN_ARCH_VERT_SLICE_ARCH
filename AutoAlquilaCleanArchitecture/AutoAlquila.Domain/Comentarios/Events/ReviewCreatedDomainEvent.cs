using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Comentarios.Events
{
    public sealed record ReviewCreatedDomainEvent(Guid AlquilerId) : IDomainEvent;
}
