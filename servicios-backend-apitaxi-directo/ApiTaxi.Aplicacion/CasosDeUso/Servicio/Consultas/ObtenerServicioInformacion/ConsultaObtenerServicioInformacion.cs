using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion
{
    public class ConsultaObtenerServicioInformacion : IRequest<ServicioInformacionResponseDto>
    {
        public required int IdServicio { get; set; }
    }
}
