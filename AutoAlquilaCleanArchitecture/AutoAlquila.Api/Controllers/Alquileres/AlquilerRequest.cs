namespace AutoAlquila.Api.Controllers.Alquileres
{
    public sealed record AlquilerReservaRequest(Guid VehiculoId, Guid UsuarioId, DateOnly fechaInicio, DateOnly fechaFin);
}
