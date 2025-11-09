using AutoAlquila.Application.Abstractions.Messaging;

namespace AutoAlquila.Application.Vehiculos.BuscarVehiculos
{
    public sealed record BuscarVehiculosQuery(DateOnly fechaInicio, DateOnly fechaFin) : IQuery<IReadOnlyList<VehiculoResponse>>;

}
