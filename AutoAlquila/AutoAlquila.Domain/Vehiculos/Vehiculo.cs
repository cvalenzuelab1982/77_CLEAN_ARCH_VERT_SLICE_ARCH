using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Vehiculos
{
    public sealed class Vehiculo : Entity
    {
        public Modelo? Modelo { get; private set; } //Objeto de valor(objet value) de DDD, no necesita de ID, solo sus valores
        public Vin? Vin { get; private set; } //Objeto de valor(objet value) de DDD, no necesita de ID, solo sus valores
        public Direccion? Direccion { get; private set; } //Objeto de valor(objet value) de DDD, no necesita de ID, solo sus valores
        public Moneda? Precio { get; private set; } //Objeto de valor(objet value) de DDD, no necesita de ID, solo sus valores
        public Moneda? Mantenimiento { get; private set; } //Objeto de valor(objet value) de DDD, no necesita de ID, solo sus valores
        public DateTime? FechaUltimaAlquiler { get; private set; }
        public List<Accesorio> Accesorios { get; private set; } = new();

        public Vehiculo(
            Guid id,
            Modelo modelo,
            Vin vin,
            Moneda precio,
            Moneda mantenimiento,
            DateTime? fechaUltimaAlquiler,
            List<Accesorio> accesorios,
            Direccion direccion
        ) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimaAlquiler = fechaUltimaAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }
    }
}
