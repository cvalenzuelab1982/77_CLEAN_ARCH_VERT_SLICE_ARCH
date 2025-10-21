using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio
{
    public class CmdCrearServicio : IRequest<int>
    {
        public required int Id { get; set; }
        public required string Ruc { get; set; }
        public required string FechaServicio { get; set; }
        public required string CodigoCentrocosto { get; set; }
        public required string OrdendeServicio { get; set; }
        public required int IdTipoServicio { get; set; }
        public required int IdTipoPago { get; set; }
        public required decimal TotalServicio { get; set; }
        public required decimal DistanciaKilometro { get; set; }
        public required string Observacion { get; set; }
        public required List<DestinoDto> Destinos { get; set; }
        public required List<ClienteDto> Clientes { get; set; }
    }
}
