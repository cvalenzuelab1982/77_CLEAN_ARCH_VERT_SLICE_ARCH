using AutoAlquila.Application.Abstractions.Messaging;

namespace AutoAlquila.Application.Alquileres.ReservarAlquiler
{
    public record ReservarAlquilerCmd(
        Guid VehiculoId,
        Guid UsuarioId,
        DateOnly FechaInicio,
        DateOnly FechaFin
    ): ICommand<Guid>;
}
