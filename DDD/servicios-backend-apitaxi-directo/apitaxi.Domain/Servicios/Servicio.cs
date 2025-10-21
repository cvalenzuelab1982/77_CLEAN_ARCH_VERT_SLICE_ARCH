using apitaxi.Domain.Abstractions;
using apitaxi.Domain.Servicios.ValueObject;

namespace apitaxi.Domain.Servicios
{
    public sealed class Servicio : Entity
    {
        private readonly int ruc;

        public string? Ruc { get; private set; }
        public string? FechaServicio { get; private set; }
        public CodigoCentrocosto? CodigoCentrocosto { get; private set; }
        public OrdendeServicio? OrdendeServicio { get; private set; }
        public TipoServicio? IdTipoServicio { get; private set; }
        public TipoPago? IdTipoPago { get; private set; }
        public decimal TotalServicio { get; private set; }
        public decimal DistanciaKilometro { get; private set; }
        public string? Observacion { get; private set; }

        private readonly List<Destino> _Destinos = new();
        public IReadOnlyCollection<Destino> destinos => _Destinos.AsReadOnly();

        private readonly List<Cliente> _Clientes = new();
        public IReadOnlyCollection<Cliente> clientes => _Clientes.AsReadOnly();

        public Servicio(
            int id,
            string ruc,
            string fechaServicio,
            CodigoCentrocosto? codigoCentrocosto,
            OrdendeServicio? ordendeServicio,
            TipoServicio? idTipoServicio,
            TipoPago? idTipoPago,
            decimal totalServicio,
            decimal distanciaKilometro,
            string? observacion,
            IEnumerable<Destino> destinos) : base(id)
        {
            if (destinos == null || !destinos.Any())
            {
                throw new ApplicationException("Debe existir al menos un destino.");
            }

            Ruc = ruc;
            FechaServicio = fechaServicio;
            CodigoCentrocosto = codigoCentrocosto;
            OrdendeServicio = ordendeServicio;
            IdTipoServicio = idTipoServicio;
            IdTipoPago = idTipoPago;
            TotalServicio = totalServicio;
            DistanciaKilometro = distanciaKilometro;
            Observacion = observacion;
            _Destinos.AddRange(destinos);
            _Clientes.AddRange(clientes);

        }
    }
}
