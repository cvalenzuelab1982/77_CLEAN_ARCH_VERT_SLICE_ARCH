using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados
{
    public class ConsultaObtenerServiciosRealizados : IRequest<List<ServicioRealizadoResponseDto>>
    {
        public required int TipoDocumentoCliente { get; set; }
        public required string NumeroDocumentoCliente { get; set; }
        public required string Ruc { get; set; }
    }
}
