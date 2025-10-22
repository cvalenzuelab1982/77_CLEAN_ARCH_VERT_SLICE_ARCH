using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Persistencia;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Dominio.Entidades;
using ApiTaxi.Dominio.ObjetoValor;
using NSubstitute;

namespace ApiTaxi.Pruebas.Aplicacion.CasosDeUso.Servicio
{
    [TestClass]
    public class CasoDeUsoCrearServiciosTests
    {
        private IRepositorioServicios repositorio;
        private IUnitOfWork unitOfWork;
        private CasoDeUsoCrearServicio casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            repositorio = Substitute.For<IRepositorioServicios>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            casoDeUso = new CasoDeUsoCrearServicio(repositorio, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_CmdValido_ObtenerIdServicio()
        {
            var comando = new CmdCrearServicio
            {
                Id = 1,
                Ruc = "1234567890",
                FechaServicio = "2025-03-03 14:05:00",
                CodigoCentrocosto = "123456",
                OrdendeServicio = "qwertyu",
                IdTipoServicio = 1,
                IdTipoPago = 1,
                TotalServicio = 10,
                DistanciaKilometro = 10,
                Observacion = "qwerty",
                Destinos = new List<DestinoRequestDto>
                {
                    new DestinoRequestDto
                    {
                        LatitudOrigen = 1,
                        LongitudOrigen = 1,
                        LatitudDestino = 1,
                        LongitudDestino= 1,
                        DireccionOrigen = "qwerty",
                        NumeroDireccionOrigen = 1,
                        DireccionDestino = "qwerty",
                        NumeroDireccionDestino= 1,
                        Orden = 1,
                        DistanciaDestinoKilometro= 1,
                        Precio = 1,
                        FechaInicio = "2025-03-03 14:05:00",
                        FechaFin = "2025-03-03 14:15:00",
                        ZonaOrigen = "origen",
                        ZonaDestino = "destino",
                        Negociado = true
                    }
                },
                Clientes = new List<ClienteRequestDto>
                {
                    new ClienteRequestDto
                    {
                        TipoDocumentoCliente = 1,
                        NumeroDocumentoCliente = "12345678",
                        NombreCliente = "qwerty",
                        ApellidosCliente = "qwerty",
                        Telefono = "12312345",
                        CodigoCentroCosto = "asdfg",
                        Negociado = true
                    }
                }
            };


            var tipoServicio = new TipoServicio(1);
            var tipopago = new TipoPago(2);
            var tipodocumento = new TipoDocumento(4);
            var intervaloTiempo = new IntervaloTiempo("2025-10-20 14:05:00", "2025-10-20 14:15:00");
            var servicioCreado = new ApiTaxi.Dominio.Entidades.Servicio(
                1,
                "123",
                "123",
                "123",
                "123",
                tipoServicio,
                tipopago,
                0,
                0,
                "hola",
                new List<Destino>
                {
                    new Destino
                    (
                        0,
                        1,
                        0,
                        0,
                        0,
                        0,
                        "origen",
                        0,
                        "destino",
                        0,
                        0,
                        0,
                        0,
                        intervaloTiempo,
                        "origen",
                        "destino",
                        true,
                        null
                    )
                },
                new List<Cliente>
                {
                    new Cliente
                    (
                        0,
                        1,
                        tipodocumento,
                        "numdoc",
                        "nombre",
                        "apelliods",
                        "telefono",
                        "codcosto",
                        true,
                        null
                    )
                }
            );
            repositorio.Agregar(Arg.Any<ApiTaxi.Dominio.Entidades.Servicio>()).Returns(servicioCreado);

            var resultado = await casoDeUso.Handle(comando);

            await repositorio.Received(1).Agregar(Arg.Any<ApiTaxi.Dominio.Entidades.Servicio>());
            await unitOfWork.Received(1).Persistir();
            Assert.AreNotEqual(0, resultado);
        }
    }
}
