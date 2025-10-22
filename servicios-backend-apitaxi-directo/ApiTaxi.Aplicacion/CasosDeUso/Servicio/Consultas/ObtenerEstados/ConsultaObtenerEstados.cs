using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados
{
    public class ConsultaObtenerEstados : IRequest<EstadoDto>
    {
        public required int IdServicio { get; set; }
    }
}
