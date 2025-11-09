using AutoAlquila.Application.Abstractions.Data;
using AutoAlquila.Application.Abstractions.Messaging;
using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Alquileres;
using Dapper;

namespace AutoAlquila.Application.Vehiculos.BuscarVehiculos
{
    internal sealed class BuscarVehiculosQueryHandler : IQueryHandler<BuscarVehiculosQuery, IReadOnlyList<VehiculoResponse>>
    {
        private readonly int[] ActiveAlquilerStatuses =
        {
            (int)AlquilerStatus.Reservado,
            (int)AlquilerStatus.Confirmado,
            (int)AlquilerStatus.Completado
        };

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public BuscarVehiculosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(BuscarVehiculosQuery request, CancellationToken cancellationToken)
        {
            if (request.fechaInicio > request.fechaFin)
            {
                return new List<VehiculoResponse>();
            }

            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    a.Id AS Id,
                    a.Modelo AS Modelo,
                    a.Vin AS Vin,
                    a.Precio_Monto AS Precio,
                    a.Precio_tipoMoneda AS TipoMoneda,
                    a.Direccion_Pais AS Pais,
                    a.Direccion_Departamento AS Departamento,
                    a.Direccion_Provincia AS Provincia,
                    a.Direccion_Ciudad AS Ciudad,
                    a.Direccion_Calle AS Calle
                FROM vehiculos a
                WHERE NOT EXISTS
                (
                    SELECT 1
                    FROM alquileres b
                    WHERE
                        b.Id = a.Id AND
                        b.Duracion_Inicio <= @EndDate AND
                        b.Duracion_Fin >= @StartDate AND
                        b.Status IN @ActiveAlquilerStatuses
                );
            """;

            var vehiculos = await connection.QueryAsync<VehiculoResponse, DireccionReponse, VehiculoResponse>(
                sql,
                (vehiculo, direccion) => //Preparando la estructura de la respuesta objeto anidado
                {
                    vehiculo.Direccion = direccion;
                    return vehiculo;
                },
                new //Preparando los parametro INPUTS
                {
                    StartDate = request.fechaInicio,
                    EndDate = request.fechaFin,
                    ActiveAlquilerStatuses
                },//Separando los resultado entre Vehiculos y Pais
                splitOn: "Pais"
            );

            return vehiculos.ToList();
        }
    }
}
