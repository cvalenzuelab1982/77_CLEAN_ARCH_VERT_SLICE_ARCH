namespace apitaxi.Domain.Servicios.ValueObject
{
    public record TipoPago
    {
        public int Id { get; init; }
        public static readonly TipoPago Credito = new(1);
        public static readonly TipoPago Efectivo = new(2);
        public static readonly TipoPago Vale = new(3);

        private TipoPago(int id)
        {
            Id = id;
        }

        public static readonly IReadOnlyCollection<TipoPago> All = new[]
        {
            Credito,
            Efectivo,
            Vale
        };

        public static TipoPago FromId(int id)
        {
            var tipo = All.FirstOrDefault(x => x.Id == id);
            if (tipo is null)
            {
                throw new ApplicationException("El tipo de pago es invalido");
            }
            return tipo;
        }
    }
}
