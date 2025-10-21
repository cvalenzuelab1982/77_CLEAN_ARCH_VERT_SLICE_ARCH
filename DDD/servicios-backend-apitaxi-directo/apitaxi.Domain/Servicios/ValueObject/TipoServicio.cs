namespace apitaxi.Domain.Servicios.ValueObject
{
    public record TipoServicio
    {
        public int Id {get;init;}
        public static readonly TipoServicio Normal = new(1);
        public static readonly TipoServicio PorHoras = new(2);
        public static readonly TipoServicio Mensajeria = new(3);

        private TipoServicio(int id)
        {
            Id = id;    
        }

        public static readonly IReadOnlyCollection<TipoServicio> All = new[]
        {
            Normal,
            PorHoras,
            Mensajeria
        };

        public static TipoServicio FromId(int id)
        {
            var tipo = All.FirstOrDefault(x => x.Id == id);
            if (tipo is null)
            {
                throw new ApplicationException("El tipo de servicio es invalido");
            }
            return tipo;
        }
    }
}
