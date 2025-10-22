namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class DestinoRequestDto
    {
        public required decimal LatitudOrigen { get; set; }
        public required decimal LongitudOrigen { get; set; }
        public required decimal LatitudDestino { get; set; }
        public required decimal LongitudDestino { get; set; }
        public required string DireccionOrigen { get; set; }
        public required int NumeroDireccionOrigen { get; set; }
        public required string DireccionDestino { get; set; }
        public required int NumeroDireccionDestino { get; set; }
        public required int Orden { get; set; }
        public required decimal DistanciaDestinoKilometro { get; set; }
        public required decimal Precio { get; set; }
        public string FechaInicio { get; set; } = null!;
        public string FechaFin { get; set; } = null!;
        public required string ZonaOrigen { get; set; } 
        public required string ZonaDestino { get; set; }
        public required bool Negociado { get; set; }
    }
}
