using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitaxi.Domain.Servicios.ValueObject
{
    public record Cliente
    {
        public TipoDocumento? TipoDocumentoCliente { get; }
        public string? NumeroDocumentoCliente { get; }
        public string? NombreCliente { get; }
        public string? ApellidosCliente { get; }
        public string? Telefono { get; }
        public string? CodigoCentroCosto { get; }
        public bool FlagPrincipal { get; }

        public Cliente(
            TipoDocumento tipoDocumento,
            string numeroDocumentoCliente,
            string nombreCliente,
            string apellidosCliente,
            string telefono,
            string? codigoCentroCosto,
            bool flagPrincipal)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumentoCliente))
                throw new ApplicationException("El número de documento del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(nombreCliente))
                throw new ApplicationException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(apellidosCliente))
                throw new ApplicationException("Los apellidos del cliente son obligatorios.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ApplicationException("El teléfono del cliente es obligatorio.");

            TipoDocumentoCliente = tipoDocumento;
            NumeroDocumentoCliente = numeroDocumentoCliente;
            NombreCliente = nombreCliente;
            ApellidosCliente = apellidosCliente;
            Telefono = telefono;
            CodigoCentroCosto = codigoCentroCosto;
            FlagPrincipal = flagPrincipal;
        }
    }
}
