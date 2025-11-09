using AutoAlquila.Application.Pruebas.ObtenerListaPruebas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoAlquila.Api.Controllers.Pruebas
{
    [ApiController]
    [Route("api/pruebas")]
    public class PruebasController : ControllerBase
    {
        private readonly ISender _sender;

        public PruebasController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListaPruebas()
        {
            var query = new ObtenerListaPruebasQuery();
            var resultados = await _sender.Send(query);
            return Ok(resultados);
        }
    }
}
