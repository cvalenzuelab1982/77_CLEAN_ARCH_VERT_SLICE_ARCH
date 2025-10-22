namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos
{
    public class TarifarioDto
    {
        public required decimal Total { get; set; }
        public required List<DestinoResponseDto> ListaDestino { get; set; }
        public required decimal DistanciaKilometro { get; set; }
        public required int IdTipoServicio { get; set; }
        public required int IdTipoPago { get; set; }

    }
}
