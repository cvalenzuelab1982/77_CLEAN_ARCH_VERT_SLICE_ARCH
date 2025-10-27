using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Alquileres.Events
{
    public sealed record AlquilerRechazadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
