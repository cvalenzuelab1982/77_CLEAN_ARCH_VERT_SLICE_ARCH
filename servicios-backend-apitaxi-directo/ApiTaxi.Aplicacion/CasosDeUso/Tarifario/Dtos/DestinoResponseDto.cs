namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos
{
    public class DestinoResponseDto
    {
        public required decimal LatitudOrigen { get; set; }
        public required decimal LongitudOrigen { get; set; }
        public required decimal LatitudDestino { get; set; }
        public required decimal LongitudDestino { get; set; }
        public required string DireccionOrigen { get; set; } = null!;
        public required int NumeroDireccionOrigen { get; set; }
        public required string DireccionDestino { get; set; } = null!;
        public required int NumeroDireccionDestino { get; set; }
        public required int Orden { get; set; }
        public required decimal DistanciaDestinoKilometro { get; set; }
        public required decimal Precio { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public required string ZonaOrigen { get; set; } = null!;
        public required string ZonaDestino { get; set; } = null!;
        public required bool Negociado { get; set; }
    }
}
