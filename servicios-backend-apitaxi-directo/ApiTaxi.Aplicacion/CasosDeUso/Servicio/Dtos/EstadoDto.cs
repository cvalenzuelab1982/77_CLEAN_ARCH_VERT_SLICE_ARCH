namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class EstadoDto
    {
        public int IdEstado { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public decimal Minutos { get; set; }
        public decimal DistanciaKilometro { get; set; }
        public ConductorResponseDto Conductor { get; set; } = new();
        public AutomovilResponseDto Automovi { get; set; } = new();
    }
}
