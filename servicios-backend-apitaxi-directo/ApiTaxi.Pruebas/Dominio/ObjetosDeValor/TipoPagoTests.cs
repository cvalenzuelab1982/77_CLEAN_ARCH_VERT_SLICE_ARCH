using ApiTaxi.Dominio.Excepciones;
using ApiTaxi.Dominio.ObjetoValor;

namespace ApiTaxi.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class TipoPagoTests
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_TipoPagoNoValido_LanzaExcepcion()
        {
            new TipoPago(0);
        }

        [TestMethod]
        public void Constructor_TipoPagoValido()
        {
            new TipoPago(1);
        }
    }
}
