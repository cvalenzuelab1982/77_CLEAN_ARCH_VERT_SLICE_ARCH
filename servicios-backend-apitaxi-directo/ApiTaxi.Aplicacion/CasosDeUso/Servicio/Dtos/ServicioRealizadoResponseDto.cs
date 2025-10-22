namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ServicioRealizadoResponseDto
    {
        public int IdServicio { get; set; }
        public int IdEstado { get; set; }
        public string CodigoCentroCosto { get; set; } = null!;
        public string FechaServicio { get; set; } = null!;
        public decimal Total { get; set; }
        public List<DestinoResponseDto> ListaDestino { get; set; } = new();
        public ConductorResponseDto Conductor { get; set; } = new();
        public AutomovilResponseDto Automovil { get; set; } = new();
        public int IdTipoServicio { get; set; }
        public int IdTipoPago { get; set; }
        public List<TrackingResponseDto> ListaTracking { get; set; } = new();
    }
}
