namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpDestinoResponseDto
    {
        public decimal LatitudOrigen { get; set; }
        public decimal LongitudOrigen { get; set; }
        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public int NumeroDireccionOrigen { get; set; }
        public string DireccionDestino { get; set; } = null!;
        public int NumeroDireccionDestino { get; set; }
        public int Orden { get; set; }
        public decimal DistanciaDestinoKilometro { get; set; }
        public decimal Precio { get; set; }
        public string FechaInicio { get; set; } = null!;
        public string FechaFin { get; set; } = null!;
        public string ZonaOrigen { get; set; } = null!;
        public string ZonaDestino { get; set; } = null!;
        public bool Negociado { get; set; }
    }
}
