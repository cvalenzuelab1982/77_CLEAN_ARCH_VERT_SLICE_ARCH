namespace AutoAlquila.Domain.Vehiculos
{
    public record Moneda(decimal Monto, TipoMoneda tipoMoneda)
    {
        public static Moneda operator +(Moneda primero, Moneda segundo)
        {
            if (primero.tipoMoneda != segundo.tipoMoneda)
            {
                throw new InvalidOperationException("El tipo de moneda debe ser el mismo");
            }

            return new(primero.Monto + segundo.Monto, primero.tipoMoneda);
        }

        public static Moneda Zero()
        {
            return new(0, TipoMoneda.None);
        }

        public static Moneda Zero(TipoMoneda tipoMoneda)
        {
            return new(0, tipoMoneda);
        }

        public bool IsZero()
        {
            return this == Zero(tipoMoneda);
        }
    }
}
