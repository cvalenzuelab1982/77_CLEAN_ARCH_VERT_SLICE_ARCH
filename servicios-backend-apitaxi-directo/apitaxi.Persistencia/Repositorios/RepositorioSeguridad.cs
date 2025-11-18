using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Comandos.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Persistencia.Servicios.Auditoria;
using ApiTaxi.Persistencia.Servicios.Red;
using ApiTaxi.Persistencia.Servicios.Seguridad;
using ApiTaxi.Persistencia.Servicios.Sistema;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.NetworkInformation;


namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        private readonly IEncripta _encripta;
        private readonly INetworkHelper _networkHelper;
        private readonly ISistemaServicio _sistemaServicio;
        private readonly string _connectionString;

        public RepositorioSeguridad(IEncripta encripta, INetworkHelper networkHelper, ISistemaServicio sistemaServicio, IConfiguration configuration, IContextoUsuarioActual contextoUsuario)
        {
            _encripta = encripta;
            _networkHelper = networkHelper;
            _sistemaServicio = sistemaServicio;
            _connectionString = configuration.GetConnectionString("ApitaxiConnectionString") ?? throw new ArgumentNullException("Conexion no encontrada");
        }

        public async Task<ValidacionLoginResponseDto> Autenticar(CmdValidacionLogin request)
        {
            var pass = _encripta.Encriptar(request.Password);
            var host = _networkHelper.GetFQDN();
            var ip = _networkHelper.GetLocalIPv4(NetworkInterfaceType.Ethernet) ?? "0.0.0.0";
            var version = _sistemaServicio.ObtenerVersion();

            using SqlConnection cn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("X12_SEG_Usuario_Login", cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 80) { Value = request.Usuario });
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100) { Value = pass });
            cmd.Parameters.Add(new SqlParameter("@Aplicacion", SqlDbType.Int) { Value = 1 }); //es aplicacion(int) o grant_type(varchar)
            cmd.Parameters.Add(new SqlParameter("@Host", SqlDbType.VarChar, 20) { Value = host });
            cmd.Parameters.Add(new SqlParameter("@IpAddress", SqlDbType.VarChar, 40) { Value = ip });
            cmd.Parameters.Add(new SqlParameter("@VersionApp", SqlDbType.VarChar, 40) { Value = version });

            await cn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            var resultado = new ValidacionLoginResponseDto();

            /*
             NE --Usuario no existe
             BA --Usuario de Baja
             BL --Usuario Bloqueado
             IN --Autenticacion no valida
             VALID - Autenticacion Correcta
             */

            if (await reader.ReadAsync())
            {
                resultado.Estado = reader["Estado"].ToString()?? string.Empty;
                resultado.IdUsuario = reader["IdUsuario"].ToString() ?? string.Empty;

                //CONSULTAR SI EN EL SP DE LOGIN ENVIA DATOS PARA SU PROPIA AUDITORIA
                //await LogInicioSesion(resultado, host, ip, version);  <=============================
            }

            return resultado;
        }

        private async Task LogInicioSesion(ValidacionLoginResponseDto request, string host, string ip, string version)
        {
            var fecha = _sistemaServicio.ObtenerFechaHoraLima();

            using SqlConnection cn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("loginiciosesiones", cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 80) { Value = request.IdUsuario ?? (object)DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 10) { Value = request.Estado ?? (object)DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@FechaInicioSesion", SqlDbType.DateTime) { Value = fecha });
            cmd.Parameters.Add(new SqlParameter("@IpAddress", SqlDbType.VarChar, 40) { Value = ip ?? (object)DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Host", SqlDbType.VarChar, 50) { Value = host ?? (object)DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@VersionApp", SqlDbType.VarChar, 40) { Value = version ?? (object)DBNull.Value });
            await cn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
