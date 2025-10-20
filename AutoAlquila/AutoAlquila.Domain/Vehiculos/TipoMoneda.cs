namespace AutoAlquila.Domain.Vehiculos
{
    public record TipoMoneda
    {
        public string? Codigo { get; init; }
        public static readonly TipoMoneda None = new("");
        public static readonly TipoMoneda Usd = new("USD");
        public static readonly TipoMoneda Eur = new("EUR");
        public static readonly IReadOnlyCollection<TipoMoneda> All = new[]
        {
            Usd,
            Eur
        };

        public TipoMoneda(string codigo)
        {
            Codigo = codigo;
        }

        public static TipoMoneda FromCodigo(string codigo)
        {
            return All.FirstOrDefault(c => c.Codigo == codigo) ?? throw new ApplicationException("El tipo de moneda es invalido");
        }

    }
}
