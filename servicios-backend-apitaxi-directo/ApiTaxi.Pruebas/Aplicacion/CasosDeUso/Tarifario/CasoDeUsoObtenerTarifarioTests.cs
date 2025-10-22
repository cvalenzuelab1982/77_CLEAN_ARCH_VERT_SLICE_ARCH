using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace ApiTaxi.Pruebas.Aplicacion.CasosDeUso.Tarifario
{
    [TestClass]
    public class CasoDeUsoObtenerTarifarioTests
    {
        private IRepositorioTarifario _repositorio;
        private CasoDeUsoObtenerTarifario _casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            _repositorio = Substitute.For<IRepositorioTarifario>();
            _casoDeUso = new CasoDeUsoObtenerTarifario(_repositorio);
        }

        [TestMethod]
        public async Task Handle_TarifarioExiste_RetornaDTO()
        {
            var tarifarioResponse = new TarifarioDto
            {
                Total = 10,
                ListaDestino = new List<DestinoResponseDto>
                {
                    new DestinoResponseDto
                    {
                        LatitudOrigen = 1,
                        LongitudOrigen = 1,
                        LatitudDestino = 1,
                        LongitudDestino = 1,
                        DireccionOrigen = "qwerty",
                        NumeroDireccionOrigen = 1,
                        DireccionDestino = "qwet",
                        NumeroDireccionDestino = 1,
                        Orden = 1,
                        DistanciaDestinoKilometro = 1,
                        Precio = 100,
                        FechaInicio = "qwert",
                        FechaFin = "qwewf",
                        ZonaOrigen = "dwad",
                        ZonaDestino = "adsf",
                        Negociado = true
                    }
                },
                DistanciaKilometro = 10,
                IdTipoServicio = 1,
                IdTipoPago = 1
            };

            var consultaRequest = new ConsultaObtenerTarifario
            {
                ListaDestinos = new List<DestinoRequestDto>
                {
                    new DestinoRequestDto
                    {
                        LatitudOrigen = 1,
                        LongitudOrigen = 1,
                        LatitudDestino = 1,
                        LongitudDestino = 1,
                        DireccionOrigen = "qwerty",
                        NumeroDireccionOrigen = 1,
                        DireccionDestino = "qwet",
                        NumeroDireccionDestino = 1,
                        Orden = 1,
                    }
                },
                IdTipoServicio = 1,
                IdTipoPago = 1
            };

            _repositorio.ObtenerTarifario(consultaRequest).Returns(tarifarioResponse);

            var resultado = await _casoDeUso.Handle(consultaRequest);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_TarifarioNoExiste_LanzaExcepcionNoEncontrado()
        {
            var consultaRequest = new ConsultaObtenerTarifario
            {
                ListaDestinos = new List<DestinoRequestDto>
                {
                    new DestinoRequestDto
                    {
                        LatitudOrigen = 1,
                        LongitudOrigen = 1,
                        LatitudDestino = 1,
                        LongitudDestino = 1,
                        DireccionOrigen = "qwerty",
                        NumeroDireccionOrigen = 1,
                        DireccionDestino = "qwet",
                        NumeroDireccionDestino = 1,
                        Orden = 1,
                    }
                },
                IdTipoServicio = 1,
                IdTipoPago = 1
            };

            _repositorio.ObtenerTarifario(consultaRequest).ReturnsNull();

            await _casoDeUso.Handle(consultaRequest);
        }
    }
}
