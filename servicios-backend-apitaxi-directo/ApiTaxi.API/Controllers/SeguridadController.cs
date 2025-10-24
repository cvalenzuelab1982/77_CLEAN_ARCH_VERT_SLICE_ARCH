using ApiTaxi.API.DTOs.Segurirdad;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Comandos.ObtenerLogin;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaxi.API.Controllers
{
    [ApiController]
    [Route("api/v1/seguridad")]
    public class SeguridadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeguridadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Autenticar(ValidacionLoginRequestDto request)
        {
            var consulta = new CmdValidacionLogin
            {
                Usuario = request.Usuario,
                Password = request.Password,
                grant_type = request.grant_type
            };

            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }
    }
}
