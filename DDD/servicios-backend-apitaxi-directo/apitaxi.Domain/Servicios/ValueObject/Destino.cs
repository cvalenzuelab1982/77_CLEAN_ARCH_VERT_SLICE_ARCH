namespace apitaxi.Domain.Servicios.ValueObject
{
    public record Destino
    {
        public decimal LatitudOrigen { get; }
        public decimal LongitudOrigen { get; }
        public decimal LatitudDestino { get; }
        public decimal LongitudDestino { get; }
        public string? DireccionOrigen { get; }
        public int NumeroDireccionOrigen { get; }
        public string? DireccionDestino { get; }
        public int NumeroDireccionDestino { get; }
        public int Orden { get; }
        public decimal DistanciaDestinoKilometro { get; }
        public decimal Precio { get; }
        public string? FechaInicio { get; }
        public string? FechaFin { get; }
        public string? ZonaOrigen { get; }
        public string? ZonaDestino { get; }
        public bool Negociado { get; }

        public Destino
        (
            decimal latitudOrigen,
            decimal longitudOrigen,
            decimal latitudDestino,
            decimal longitudDestino,
            string direccionOrigen,
            int numeroDireccionOrigen,
            string direccionDestino,
            int numeroDireccionDestino,
            int orden,
            decimal distanciaDestinoKilometro,
            decimal precio,
            string? fechaInicio,
            string? fechaFin,
            string zonaOrigen,
            string zonaDestino,
            bool negociado)
        {
            if (latitudOrigen is < -90 or > 90)
                throw new ApplicationException("La LatitudOrigen debe estar entre -90 y 90.");

            if (longitudOrigen is < -180 or > 180)
                throw new ApplicationException("La LongitudOrigen debe estar entre -180 y 180.");

            if (latitudDestino is < -90 or > 90)
                throw new ApplicationException("La LatitudDestino debe estar entre -90 y 90.");

            if (longitudDestino is < -180 or > 180)
                throw new ApplicationException("La LongitudDestino debe estar entre -180 y 180.");

            // Direcciones
            if (string.IsNullOrWhiteSpace(direccionOrigen))
                throw new ApplicationException("La dirección de origen es obligatoria.");

            if (string.IsNullOrWhiteSpace(direccionDestino))
                throw new ApplicationException("La dirección de destino es obligatoria.");

            if (direccionOrigen.Length > 250)
                throw new ApplicationException("La dirección de origen no puede superar los 250 caracteres.");

            if (direccionDestino.Length > 250)
                throw new ApplicationException("La dirección de destino no puede superar los 250 caracteres.");

            // Zonas
            if (string.IsNullOrWhiteSpace(zonaOrigen))
                throw new ApplicationException("La zona de origen es obligatoria.");

            if (string.IsNullOrWhiteSpace(zonaDestino))
                throw new ApplicationException("La zona de destino es obligatoria.");

            // Numéricos y rangos
            if (numeroDireccionOrigen <= 0)
                throw new ApplicationException("El número de dirección de origen debe ser mayor a cero.");

            if (numeroDireccionDestino <= 0)
                throw new ApplicationException("El número de dirección de destino debe ser mayor a cero.");

            if (orden <= 0)
                throw new ApplicationException("El número de orden del destino debe ser mayor a cero.");

            if (distanciaDestinoKilometro <= 0)
                throw new ApplicationException("La distancia debe ser mayor a cero.");

            if (precio < 0)
                throw new ApplicationException("El precio no puede ser negativo.");

            LatitudOrigen = Math.Round(latitudOrigen, 12);
            LongitudOrigen = Math.Round(longitudOrigen, 12);
            LatitudDestino = Math.Round(latitudDestino, 12);
            LongitudDestino = Math.Round(longitudDestino, 12);
            DireccionOrigen = direccionOrigen.Trim();
            NumeroDireccionOrigen = numeroDireccionOrigen;
            DireccionDestino = direccionDestino.Trim();
            NumeroDireccionDestino = numeroDireccionDestino;
            Orden = orden;
            DistanciaDestinoKilometro = Math.Round(distanciaDestinoKilometro, 5);
            Precio = Math.Round(precio, 5);
            FechaInicio = fechaInicio?.Trim();
            FechaFin = fechaFin?.Trim();
            ZonaOrigen = zonaOrigen.Trim();
            ZonaDestino = zonaDestino.Trim();
            Negociado = negociado;
        }
    }
}
