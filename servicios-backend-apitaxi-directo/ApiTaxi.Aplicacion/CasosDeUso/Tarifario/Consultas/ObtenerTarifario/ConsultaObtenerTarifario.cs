using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario
{
    public class ConsultaObtenerTarifario : IRequest<TarifarioDto>
    {
        public List<DestinoRequestDto> ListaDestinos { get; set; } = new();
        public int IdTipoServicio { get; set; }
        public int IdTipoPago { get; set; }
    }
}
