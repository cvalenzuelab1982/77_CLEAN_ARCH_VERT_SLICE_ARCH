namespace AutoAlquila.Domain.Alquileres
{
    public sealed record RangoFechas
    {
        public DateOnly Inicio { get; init; }
        public DateOnly Fin { get; init; }

        public RangoFechas()
        {
        }

        public int CantidadDias => Fin.DayNumber - Inicio.DayNumber;

        public static RangoFechas Create(DateOnly inicio, DateOnly fin)
        {
            if (inicio > fin)
            {
                throw new ApplicationException("La fecha final es anterior a la fecha de inicio.");
            }

            return new RangoFechas
            {
                Inicio = inicio,
                Fin = fin
            };
        }
    }
}
