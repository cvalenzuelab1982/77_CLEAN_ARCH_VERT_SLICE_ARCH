using ApiTaxi.Aplicacion.Contratos.Persistencia;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using ApiTaxi.Dominio.ObjetoValor;
using FluentValidation;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio
{
    public class CasoDeUsoCrearServicio : IRequestHandler<CmdCrearServicio, int>
    {
        private readonly IRepositorioServicios _Repositorio;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IValidator<CmdCrearServicio> _Validator;

        public CasoDeUsoCrearServicio(IRepositorioServicios repositorio, IUnitOfWork unitOfWork, IValidator<CmdCrearServicio> validator)
        {
            _Repositorio = repositorio;
            _UnitOfWork = unitOfWork;
            _Validator = validator;
        }
  

        public async Task<int> Handle(CmdCrearServicio cmd)
        {
            var resultadoValidacion = await _Validator.ValidateAsync(cmd);
            if (!resultadoValidacion.IsValid)
            {
                throw new ExepcionDeValidacion(resultadoValidacion);
            }


            // --- Mapeo: DTOs → Entidades de dominio ---
            var destinosDominio = cmd.Destinos.Select(d => new Dominio.Entidades.Destino(
                id: 0,
                servicioId: 0,
                latitudOrigen: d.LatitudOrigen,
                longitudOrigen: d.LongitudOrigen,
                latitudDestino: d.LatitudDestino,
                longitudDestino: d.LongitudDestino,
                direccionOrigen: d.DireccionOrigen,
                numeroDireccionOrigen: d.NumeroDireccionOrigen,
                direccionDestino: d.DireccionDestino,
                numeroDireccionDestino: d.NumeroDireccionDestino,
                orden: d.Orden,
                distanciaDestinoKilometro: d.DistanciaDestinoKilometro,
                precio: d.Precio,
                intervaloTiempo: (string.IsNullOrWhiteSpace(d.FechaInicio) && string.IsNullOrWhiteSpace(d.FechaFin))
                    ? null
                    : new IntervaloTiempo(d.FechaInicio, d.FechaFin),
                zonaOrigen: d.ZonaOrigen,
                zonaDestino: d.ZonaDestino,
                negociado: d.Negociado,
                servicio: null
            )).ToList();

            var clientesDominio = cmd.Clientes.Select(c => new Dominio.Entidades.Cliente(
                id: 0,
                servicioId: 0,
                tipoDocumentoCliente: new TipoDocumento(c.TipoDocumentoCliente),
                numeroDocumentoCliente: c.NumeroDocumentoCliente,
                nombreCliente: c.NombreCliente,
                apellidosCliente: c.ApellidosCliente,
                telefono: c.Telefono,
                codigoCentroCosto: c.CodigoCentroCosto ?? string.Empty,
                negociado: c.Negociado,
                servicio: null
            )).ToList();

            var servicio = new Dominio.Entidades.Servicio(
                cmd.Id,
                cmd.Ruc,
                cmd.FechaServicio,
                cmd.CodigoCentrocosto,
                cmd.OrdendeServicio,
                new TipoServicio(cmd.IdTipoServicio),
                new TipoPago(cmd.IdTipoPago),
                cmd.TotalServicio,
                cmd.DistanciaKilometro,
                cmd.Observacion,
                destinosDominio,
                clientesDominio);

            try
            {
                var respuesta = await _Repositorio.Agregar(servicio);
                await _UnitOfWork.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await _UnitOfWork.Reversar();
                throw;
            }

        }


    }
}
