using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Persistencia.Servicios.Red;
using ApiTaxi.Persistencia.Servicios.Seguridad;
using ApiTaxi.Persistencia.Servicios.Sistema;
using System.Net.NetworkInformation;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        private readonly IEncripta _encripta;
        private readonly INetworkHelper _networkHelper;
        private readonly IVersionServicio _versionServicio;

        public RepositorioSeguridad(IEncripta encripta, INetworkHelper networkHelper, IVersionServicio versionServicio)
        {
            _encripta = encripta;
            _networkHelper = networkHelper;
            _versionServicio = versionServicio;
        }

        public Task<ValidacionLoginResponseDto> Autenticar(ConsultarValidacionLogin request)
        {
            var pass = _encripta.Encriptar(request.Password);
            var ip = _networkHelper.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            var version = _versionServicio.ObtenerVersion();

            throw new NotImplementedException();
        }
    }
}
