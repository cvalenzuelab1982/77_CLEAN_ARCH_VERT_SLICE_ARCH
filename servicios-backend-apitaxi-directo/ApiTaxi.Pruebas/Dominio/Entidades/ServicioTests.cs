using ApiTaxi.Dominio.Entidades;
using ApiTaxi.Dominio.ObjetoValor;

namespace ApiTaxi.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ServicioTests
    {
        [TestMethod]
        public void Constructor_Servicio()
        {
            var tipoServicio = new TipoServicio(1);
            var tipopago = new TipoPago(2);
            var tipodocumento = new TipoDocumento(4);
            var intervaloTiempo = new IntervaloTiempo("2025-10-20 14:05:00", "2025-10-20 14:15:00");

            new Servicio(
                0,
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
        }
    }
}
