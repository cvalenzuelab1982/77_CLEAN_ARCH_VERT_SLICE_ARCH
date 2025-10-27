using AutoAlquila.Domain.Vehiculos;

namespace AutoAlquila.Domain.Alquileres
{
    public record PrecioDetalle(
        Moneda PrecioPorPeriodo,
        Moneda Mantenimiento,
        Moneda Accesorios,
        Moneda PrecioTotal);
}
