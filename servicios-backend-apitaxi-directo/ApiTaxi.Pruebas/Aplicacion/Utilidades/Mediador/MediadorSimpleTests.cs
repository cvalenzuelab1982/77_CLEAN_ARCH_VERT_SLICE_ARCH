using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using NSubstitute;

namespace ApiTaxi.Pruebas.Aplicacion.Utilidades.Mediador
{
    [TestClass]
    public class MediadorSimpleTests
    {
        public class RequestFalso : IRequest<string> { }
        public class HandleFalso : IRequestHandler<RequestFalso, string>
        {
            public Task<string> Handle(RequestFalso request)
            {
                return Task.FromResult("respuesta correcta");
            }
        }

        [TestMethod]
        public async Task Send_LlamandoMetodoHandler()
        {
            var request = new RequestFalso();
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<RequestFalso, string>)).Returns(casoDeUsoMock);

            var mediador = new MediadorSimple(serviceProvider);
            var resultado = await mediador.Send(request);
            await casoDeUsoMock.Received(1).Handle(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeMediador))]
        public async Task Send_SinHandlerRegistrado_LanzaExcepcion()
        {
            var request = new RequestFalso();
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
            var serviceProvider = Substitute.For<IServiceProvider>();
            var mediador = new MediadorSimple(serviceProvider);
            var resultado = await mediador.Send(request);
        }
    }
}
