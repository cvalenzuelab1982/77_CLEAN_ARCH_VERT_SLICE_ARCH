using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio
{
    public class CmdAnularServicio : IRequest<ServicioAnularResponseDto>
    {
        public required int IdServicio { get; set; }
        public required string MotivoAnulacion { get; set; }
    }
}
