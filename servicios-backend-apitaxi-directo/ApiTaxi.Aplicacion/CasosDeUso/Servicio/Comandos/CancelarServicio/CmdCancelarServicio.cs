using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio
{
    public class CmdCancelarServicio : IRequest<ServicioCancelarResponseDto>
    {
        public required int IdServicio { get; set; }
        public required string MotivoCancelacion { get; set; }

    }
}
