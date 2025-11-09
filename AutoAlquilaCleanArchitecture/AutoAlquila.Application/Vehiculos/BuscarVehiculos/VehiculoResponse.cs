using AutoAlquila.Domain.Vehiculos;

namespace AutoAlquila.Application.Vehiculos.BuscarVehiculos
{
    public sealed class VehiculoResponse
    {
        public Guid Id { get; init; }
        public string? Modelo { get; init; }
        public string? Vin { get; init; }
        public decimal Precio { get; init; }
        public string? TipoMoneda { get; init; }
        public DireccionReponse? Direccion { get; set; }

    }
}
