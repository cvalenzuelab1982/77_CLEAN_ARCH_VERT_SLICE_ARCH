using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio
{
    public class CmdCrearServicio : IRequest<ServicioDto>
    {
        public required string Ruc { get; set; }
        public required string FechaServicio { get; set; }
        public required string CodigoCentrocosto { get; set; }
        public string OrdendeServicio { get; set; } = null!;
        public required int IdTipoServicio { get; set; }
        public required int IdTipoPago { get; set; }
        public required decimal TotalServicio { get; set; }
        public required decimal DistanciaKilometro { get; set; }
        public required string Observacion { get; set; }
        public required List<DestinoRequestDto> ListaDestino { get; set; }
        public required List<ClienteRequestDto> ListaCliente { get; set; }
    }
}
