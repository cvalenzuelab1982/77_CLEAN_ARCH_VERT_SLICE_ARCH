namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpTrackingResponseDto
    {
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string FechaTracking { get; set; } = null!;
    }
}
