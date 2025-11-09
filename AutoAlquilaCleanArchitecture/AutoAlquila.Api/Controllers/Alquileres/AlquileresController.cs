using AutoAlquila.Application.Alquileres.ObtenerAlquiler;
using AutoAlquila.Application.Alquileres.ReservarAlquiler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoAlquila.Api.Controllers.Alquileres
{
    [ApiController]
    [Route("api/alquileres")]
    public class AlquileresController : ControllerBase
    {
        private readonly ISender _sender;

        public AlquileresController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAlquiler(Guid id, CancellationToken cancellationToken)
        {
            var query = new ObtenerAlquilerQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> ReservarAlquiler(AlquilerReservaRequest request, CancellationToken cancellationToken)
        {
            var cmd = new ReservarAlquilerCmd(request.VehiculoId, request.UsuarioId, request.fechaInicio, request.fechaFin);
            var resultado = await _sender.Send(cmd, cancellationToken);

            if (resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            //ANTES DE EFECTUAR LA RESERVAR, CREA UNA ACCION ANTES, INVOCANDO AL METODO ObtenerAlquiler DE ESTE MISMO CONTROLADOR
            //PERMITE DEVOLVER LA DATA DEL NUEVO ALQUILER INGRESADO
            return CreatedAtAction(nameof(ObtenerAlquiler), new {id=resultado.Value});
        }
    }
}
