using ApiTaxi.Dominio.Excepciones;
using ApiTaxi.Dominio.ObjetoValor;

namespace ApiTaxi.Dominio.Entidades
{
    public class Servicio
    {
        public int Id { get; private set; }
        public string Ruc { get; private set; } = null!;
        public string FechaServicio { get; private set; } = null!;
        public string CodigoCentrocosto { get; private set; } = null!;
        public string OrdendeServicio { get; private set; } = null!;
        public TipoServicio IdTipoServicio { get; private set; }
        public TipoPago IdTipoPago { get; private set; }
        public decimal TotalServicio { get; private set; }
        public decimal DistanciaKilometro { get; private set; }
        public string Observacion { get; private set; } = null!;
        public List<Destino> Destinos { get; set; } = new();
        public List<Cliente> Clientes { get; set; } = new();

        public Servicio(
            int id,
            string ruc,
            string fechaServicio,
            string codigoCentrocosto,
            string ordendeServicio,
            TipoServicio idTipoServicio,
            TipoPago idTipoPago,
            decimal totalServicio,
            decimal distanciaKilometro,
            string observacion,
            List<Destino> destinos,
            List<Cliente> clientes
            )
        {
            if (string.IsNullOrWhiteSpace(ruc))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(ruc)} es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(fechaServicio))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(fechaServicio)} es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(codigoCentrocosto))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(codigoCentrocosto)} es obligatorio");
            }

            if (totalServicio < 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(totalServicio)} es invalido");
            }

            if (distanciaKilometro < 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(distanciaKilometro)} es invalido");
            }

            if (string.IsNullOrWhiteSpace(observacion))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(observacion)} es obligatorio");
            }

            if (destinos == null || destinos.Count == 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"La lista de {nameof(destinos)} es obligatorio");
            }

            if (clientes == null || clientes.Count == 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"La lista de {nameof(clientes)} es obligatorio");
            }

            Id = id;
            Ruc = ruc;
            FechaServicio = fechaServicio;
            CodigoCentrocosto = codigoCentrocosto;
            OrdendeServicio = ordendeServicio;
            IdTipoServicio = idTipoServicio;
            IdTipoPago = idTipoPago;
            TotalServicio = totalServicio;
            DistanciaKilometro = distanciaKilometro;
            Observacion = observacion;
            Destinos = destinos;
            Clientes = clientes;
        }
    }
}
