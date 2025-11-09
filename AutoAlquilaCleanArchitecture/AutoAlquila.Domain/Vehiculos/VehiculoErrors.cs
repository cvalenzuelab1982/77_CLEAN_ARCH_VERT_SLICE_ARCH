using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Vehiculos
{
    public static class VehiculoErrors
    {
        public static Error NotFound = new(
            "Vehiculo.Found",
            "No existe un vehiculo con este id"
        );
    }
}
