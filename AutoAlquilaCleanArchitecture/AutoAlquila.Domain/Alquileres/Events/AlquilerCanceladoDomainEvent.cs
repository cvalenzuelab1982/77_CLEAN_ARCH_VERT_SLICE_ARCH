using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Alquileres.Events
{
    public sealed record AlquilerCanceladoDomainEvent(Guid AlquilerID) :IDomainEvent;
    
}
