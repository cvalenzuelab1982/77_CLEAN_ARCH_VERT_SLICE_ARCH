using AutoAlquila.Application.Vehiculos.BuscarVehiculos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoAlquila.Api.Controllers.Vehiculos
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculosController : ControllerBase
    {
        private readonly ISender _sender;

        public VehiculosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarVehiculos(DateOnly fechaIncio, DateOnly fechaFin, CancellationToken cancellationToken)
        {
            var query = new BuscarVehiculosQuery(fechaIncio, fechaFin);
            var resultados = await _sender.Send(query, cancellationToken);
            return Ok(resultados.Value);
        }
    }
}
