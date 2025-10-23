using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Persistencia.Servicios.Red;
using ApiTaxi.Persistencia.Servicios.Seguridad;
using ApiTaxi.Persistencia.Servicios.Sistema;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        private readonly IEncripta _encripta;
        private readonly INetworkHelper _networkHelper;
        private readonly IVersionServicio _versionServicio;
        private readonly string _connectionString;

        public RepositorioSeguridad(IEncripta encripta, INetworkHelper networkHelper, IVersionServicio versionServicio, IConfiguration configuration)
        {
            _encripta = encripta;
            _networkHelper = networkHelper;
            _versionServicio = versionServicio;
            _connectionString = configuration.GetConnectionString("ApitaxiConnectionString") ?? throw new ArgumentNullException("Conexion no encontrada");
        }

        public async Task<ValidacionLoginResponseDto> Autenticar(ConsultarValidacionLogin request)
        {
            var pass = _encripta.Encriptar(request.Password);
            var host = _networkHelper.GetFQDN();
            var ip = _networkHelper.GetLocalIPv4(NetworkInterfaceType.Ethernet) ?? "0.0.0.0";
            var version = _versionServicio.ObtenerVersion();

            using SqlConnection cn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("X12_SEG_Usuario_Login", cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 80) { Value = request.Usuario });
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100) { Value = pass });
            cmd.Parameters.Add(new SqlParameter("@Aplicacion", SqlDbType.Int) { Value = request.Aplicacion });
            cmd.Parameters.Add(new SqlParameter("@Host", SqlDbType.VarChar, 20) { Value = host });
            cmd.Parameters.Add(new SqlParameter("@IpAddress", SqlDbType.VarChar, 40) { Value = ip });
            cmd.Parameters.Add(new SqlParameter("@VersionApp", SqlDbType.VarChar, 40) { Value = version });

            await cn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                string estado = reader.GetString(0);
                return new ValidacionLoginResponseDto { EsValido = estado.Equals("OK", StringComparison.OrdinalIgnoreCase) };
            }

            return new ValidacionLoginResponseDto { EsValido = false };
        }
    }
}
