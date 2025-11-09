using AutoAlquila.Domain.Shared;

namespace AutoAlquila.Domain.Alquileres
{
    public record PrecioDetalle(
        Moneda PrecioPorPeriodo,
        Moneda Mantenimiento,
        Moneda Accesorios,
        Moneda PrecioTotal);
}
