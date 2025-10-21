using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitaxi.Domain.Servicios.ValueObject
{
    public record TipoDocumento
    {
        public int Id { get; init; }
        public static readonly TipoDocumento DocumentoNacional = new(1);
        public static readonly TipoDocumento CarnetExtranjeria = new(2);
        public static readonly TipoDocumento Ruc = new(3);
        public static readonly TipoDocumento Pasaporte = new(4);

        private TipoDocumento(int id)
        {
            Id = id;
        }

        public static readonly IReadOnlyCollection<TipoDocumento> All = new[]
        {
            DocumentoNacional,
            CarnetExtranjeria,
            Ruc,
            Pasaporte
        };

        public static TipoDocumento FromId(int id)
        {
            var tipo = All.FirstOrDefault(x => x.Id == id);
            if (tipo is null)
            {
                throw new ApplicationException("El tipo de documento es invalido");
            }
            return tipo;
        }
    }
}
