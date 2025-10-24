using ApiTaxi.API.DTOs.Servicios;
using ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Consultas.ObtenerEstadosPush;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaxi.API.Controllers
{
    [ApiController]
    [Route("api/v1/kmmp")]
    [Authorize]
    public class KmmpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KmmpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("push")]
        public async Task<IActionResult> Push()
        {
            var consulta = new ConsultaObtenerEstadosPush();
            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);   
        }
    }
}
