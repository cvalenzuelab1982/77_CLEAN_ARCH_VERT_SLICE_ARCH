using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Shared;

namespace AutoAlquila.Domain.Vehiculos
{
    public sealed class Vehiculo : Entity
    {
        private Vehiculo()
        {
            
        }

        public Vehiculo(
            Guid id, 
            Modelo modelo, 
            Vin vin, 
            Moneda precio, 
            Moneda mantenimiento, 
            DateTime? fechaUltimaAlquiler, 
            List<Accesorio> accesorios,
            Direccion direccion) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimoAlquiler = fechaUltimaAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }

        public Modelo? Modelo { get; private set; }
        public Vin? Vin { get; private set; }
        public Direccion? Direccion { get; private set; }
        public Moneda? Precio { get; private set; }
        public Moneda? Mantenimiento { get; private set; }
        public DateTime? FechaUltimoAlquiler { get; internal set; } //internal, accesible para el dominio
        public List<Accesorio> Accesorios { get; private set; } = new();
    }
}
