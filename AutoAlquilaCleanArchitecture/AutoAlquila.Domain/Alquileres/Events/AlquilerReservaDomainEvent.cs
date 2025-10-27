using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Alquileres.Events
{
    public sealed record AlquilerReservaDomainEvent(Guid AlquilerId) : IDomainEvent;
}
