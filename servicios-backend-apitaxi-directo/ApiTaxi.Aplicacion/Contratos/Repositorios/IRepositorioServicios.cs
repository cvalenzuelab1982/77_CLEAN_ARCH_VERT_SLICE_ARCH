using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;

namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioServicios
    {
        Task<ServicioDto> RegistrarServicio(CmdCrearServicio request);
        Task<ServicioCancelarResponseDto> CancelarServicio(CmdCancelarServicio request);
        Task<ServicioAnularResponseDto> AnularServicio(CmdAnularServicio request);
        Task<EstadoDto> ObtenerEstado(ConsultaObtenerEstados request);
        Task<List<ServicioRealizadoResponseDto>> ObtenerServiciosRealizados(ConsultaObtenerServiciosRealizados request);
        Task<ServicioInformacionResponseDto> ObtenerServicioInformacion(ConsultaObtenerServicioInformacion request);
    }
}
