using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Alquileres.Events
{
    public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
