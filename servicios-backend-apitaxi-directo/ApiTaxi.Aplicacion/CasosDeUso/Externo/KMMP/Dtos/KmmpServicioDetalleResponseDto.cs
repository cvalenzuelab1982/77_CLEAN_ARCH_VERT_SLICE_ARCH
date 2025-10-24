namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpServicioDetalleResponseDto
    {
        public int IdEstado { get; set; }
        public string Observacion { get; set; } = null!;
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string FechaInicio { get; set; } = null!;
        public string FechaFin { get; set; } = null!;

    }
}
