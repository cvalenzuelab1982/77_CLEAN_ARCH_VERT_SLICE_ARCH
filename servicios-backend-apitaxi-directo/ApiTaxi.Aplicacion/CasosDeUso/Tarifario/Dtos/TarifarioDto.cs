namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos
{
    public class TarifarioDto
    {
        public decimal Total { get; set; }
        public List<DestinoResponseDto> ListaDestino { get; set; } = new();
        public decimal DistanciaKilometro { get; set; }
        public int IdTipoServicio { get; set; }
        public int IdTipoPago { get; set; }

    }
}
