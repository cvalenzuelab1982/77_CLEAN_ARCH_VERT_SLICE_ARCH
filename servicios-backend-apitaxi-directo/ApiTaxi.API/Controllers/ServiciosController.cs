using ApiTaxi.API.DTOs.Servicios;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaxi.API.Controllers
{
    [ApiController]
    [Route("api/v1/servicio")]
    public class ServiciosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiciosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarServicio([FromBody] ServicioRequestDto request)
        {
            var registro = new CmdCrearServicio
            {
                Ruc = request.Ruc,
                FechaServicio = request.FechaServicio,
                CodigoCentrocosto = request.CodigoCentrocosto,
                OrdendeServicio = request.OrdendeServicio,
                IdTipoServicio = request.IdTipoServicio,
                IdTipoPago = request.IdTipoPago,
                TotalServicio = request.TotalServicio,
                DistanciaKilometro = request.DistanciaKilometro,
                Observacion = request.Observacion,
                ListaDestino = request.ListaDestino.Select(d => new ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos.DestinoRequestDto{
                    LatitudOrigen = d.LatitudOrigen,  
                    LongitudOrigen = d.LongitudOrigen,
                    LatitudDestino = d.LatitudDestino,
                    LongitudDestino = d.LongitudDestino,
                    DireccionOrigen = d.DireccionOrigen,
                    NumeroDireccionOrigen = d.NumeroDireccionOrigen,
                    DireccionDestino = d.DireccionDestino,
                    NumeroDireccionDestino = d.NumeroDireccionDestino,
                    Orden = d.Orden,    
                    DistanciaDestinoKilometro = d.DistanciaDestinoKilometro,
                    Precio = d.Precio,
                    FechaInicio = d.FechaInicio,
                    FechaFin = d.FechaFin,
                    ZonaOrigen = d.ZonaOrigen,
                    ZonaDestino = d.ZonaDestino,
                    Negociado = d.Negociado
                }).ToList(),
                ListaCliente = request.ListaCliente.Select(c => new ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos.ClienteRequestDto
                {
                    TipoDocumentoCliente = c.TipoDocumentoCliente,
                    NumeroDocumentoCliente = c.NumeroDocumentoCliente,
                    NombreCliente = c.NombreCliente,
                    ApellidosCliente = c.ApellidosCliente,
                    Telefono = c.Telefono,
                    CodigoCentroCosto = c.CodigoCentroCosto,
                    Negociado = c.Negociado
                }).ToList()
            };

            var resultado = await _mediator.Send(registro);
            return Ok(resultado);
        }

        [HttpPost("cancelar")]
        public async Task<IActionResult> CancelarServicio([FromBody] ServicioCancelarRequestDto request)
        {
            var registro = new CmdCancelarServicio
            {
                IdServicio = request.IdServicio,
                MotivoCancelacion = request.MotivoCancelacion
            };

            var resultado = await _mediator.Send(registro);
            return Ok(resultado);
        }

        [HttpPost("anular")]
        public async Task<IActionResult> AnularServicio([FromBody] ServicioAnularRequestDto request)
        {
            var registro = new CmdAnularServicio
            {
                IdServicio = request.IdServicio,
                MotivoAnulacion = request.MotivoAnulacion
            };

            var resultado = await _mediator.Send(registro);
            return Ok(resultado);
        }

        [HttpGet("estado/{idServicio}")]
        public async Task<IActionResult> ObtenerEstado(int idServicio)
        {
            var consulta = new ConsultaObtenerEstados
            {
                IdServicio = idServicio
            };

            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpPost("realizados")]
        public async Task<IActionResult> ServiciosRealizados([FromBody] ServicioRealizadosRequestDto request)
        {
            var consulta = new ConsultaObtenerServiciosRealizados
            {
                TipoDocumentoCliente = request.TipoDocumentoCliente,
                NumeroDocumentoCliente = request.NumeroDocumentoCliente,
                Ruc = request.Ruc
            };

            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet("informacion/{idServicio}")]
        public async Task<IActionResult> ServicioInformacion(int idServicio)
        {
            var consulta = new ConsultaObtenerServicioInformacion
            {
                IdServicio = idServicio
            };

            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }
    }
}
