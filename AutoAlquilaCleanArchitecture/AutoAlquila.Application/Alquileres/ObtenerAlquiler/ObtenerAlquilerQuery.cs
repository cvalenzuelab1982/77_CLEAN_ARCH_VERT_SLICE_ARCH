using AutoAlquila.Application.Abstractions.Messaging;

namespace AutoAlquila.Application.Alquileres.ObtenerAlquiler
{
    public sealed record ObtenerAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;
}
