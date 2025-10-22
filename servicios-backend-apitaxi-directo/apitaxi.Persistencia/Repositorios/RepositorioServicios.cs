using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioServicios : IRepositorioServicios
    {
        public RepositorioServicios()
        {

        }

        public Task<ServicioAnularResponseDto> AnularServicio(CmdAnularServicio request)
        {
            throw new NotImplementedException();
        }

        public Task<ServicioCancelarResponseDto> CancelarServicio(CmdCancelarServicio request)
        {
            throw new NotImplementedException();
        }

        public Task<EstadoDto> ObtenerEstado(ConsultaObtenerEstados request)
        {
            throw new NotImplementedException();
        }

        public Task<ServicioInformacionResponseDto> ObtenerServicioInformacion(ConsultaObtenerServicioInformacion request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServicioRealizadoResponseDto>> ObtenerServiciosRealizados(ConsultaObtenerServiciosRealizados request)
        {
            throw new NotImplementedException();
        }

        public Task<ServicioDto> RegistrarServicio(CmdCrearServicio request)
        {
            throw new NotImplementedException();
        }
    }
}
