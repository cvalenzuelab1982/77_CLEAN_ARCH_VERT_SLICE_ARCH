namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class TrackingResponseDto
    {
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string FechaTracking { get; set; } = null!;
    }
}
