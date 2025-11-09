using AutoAlquila.Application.Abstractions.Data;
using AutoAlquila.Domain.Vehiculos;
using Bogus;
using Dapper;

namespace AutoAlquila.Api.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> vehiculos = new();

            for (int i = 0; i < 100; i++)
            {
                vehiculos.Add(new
                {
                    Id = Guid.NewGuid(),
                    Vin = faker.Vehicle.Vin(),
                    Modelo = faker.Vehicle.Model(),
                    Pais = faker.Address.Country(),
                    Departamento = faker.Address.State(),
                    Provincia = faker.Address.Country(),
                    Ciudad = faker.Address.City(),
                    Calle = faker.Address.StreetAddress(),
                    PrecioMonto = faker.Random.Decimal(1000, 20000),
                    PrecioTipoMoneda = "USD",
                    PrecioMantenimiento = faker.Random.Decimal(100, 200),
                    PrecioMantenimientoTipoMoneda = "USD",
                    Accesorios = string.Join(",", new List<int> { (int)Accesorio.Wifi, (int)Accesorio.AppleCar }) ,
                    FechaUltima = DateTime.UtcNow
                });
            }

            const string sql = $"""
                INSERT INTO dbo.vehiculos(Id, Modelo, Vin, Direccion_Departamento, Direccion_Provincia, Direccion_Ciudad, Direccion_Pais, Direccion_Calle, Precio_Monto, Precio_tipoMoneda, Mantenimiento_Monto, Mantenimiento_tipoMoneda, FechaUltimoAlquiler, Accesorios)
                VALUES(@Id, @Modelo, @Vin, @Departamento, @Provincia, @Ciudad, @Pais, @Calle, @PrecioMonto, @PrecioTipoMoneda, @PrecioMantenimiento, @PrecioMantenimientoTipoMoneda, @FechaUltima, @Accesorios);
            """;

            connection.Execute(sql, vehiculos);
        }
    }
}