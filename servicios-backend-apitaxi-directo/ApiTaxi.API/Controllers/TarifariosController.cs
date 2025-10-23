using ApiTaxi.API.DTOs.Tarifarios;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaxi.API.Controllers
{
    [ApiController]
    [Route("api/v1/tarifario")]
    [Authorize]
    public class TarifariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarifariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("obtener")]
        public async Task<IActionResult> ObtenerTarifario([FromBody] TarifarioRequestDto request)
        {
            var consulta = new ConsultaObtenerTarifario
            {
                IdTipoPago = request.IdTipoPago,
                IdTipoServicio = request.IdTipoServicio,
                ListaDestinos = request.ListaDestinos.Select(d => new ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos.DestinoRequestDto
                {
                    LatitudOrigen = d.LatitudOrigen,
                    LongitudOrigen = d.LongitudOrigen,
                    LatitudDestino = d.LatitudDestino,
                    LongitudDestino = d.LongitudDestino,
                    DireccionOrigen = d.DireccionOrigen,
                    NumeroDireccionOrigen = d.NumeroDireccionOrigen,
                    DireccionDestino = d.DireccionDestino,
                    NumeroDireccionDestino = d.NumeroDireccionDestino,
                    Orden = d.Orden
                }).ToList()
            };

            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }
    }



}
