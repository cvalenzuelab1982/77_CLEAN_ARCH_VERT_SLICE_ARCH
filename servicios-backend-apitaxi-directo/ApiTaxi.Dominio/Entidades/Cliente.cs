using ApiTaxi.Dominio.ObjetoValor;

namespace ApiTaxi.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; private set; }
        public int ServicioId { get; private set; }
        public TipoDocumento TipoDocumentoCliente { get; private set; }
        public string NumeroDocumentoCliente { get; private set; } = null!;
        public string NombreCliente { get; private set; } = null!;
        public string ApellidosCliente { get; private set; } = null!;
        public string Telefono { get; private set; } = null!;
        public string CodigoCentroCosto { get; private set; } = null!;
        public bool Negociado { get; private set; }
        public Servicio? Servicio { get; set; }

        public Cliente(int id, int servicioId, TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string nombreCliente, string apellidosCliente, string telefono, string codigoCentroCosto, bool negociado, Servicio? servicio)
        {
            Id = id;
            ServicioId = servicioId;
            TipoDocumentoCliente = tipoDocumentoCliente;
            NumeroDocumentoCliente = numeroDocumentoCliente;
            NombreCliente = nombreCliente;
            ApellidosCliente = apellidosCliente;
            Telefono = telefono;
            CodigoCentroCosto = codigoCentroCosto;
            Negociado = negociado;
            Servicio = servicio;
        }
    }
}
