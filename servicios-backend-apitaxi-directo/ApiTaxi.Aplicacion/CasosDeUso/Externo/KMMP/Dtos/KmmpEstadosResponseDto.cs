namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpEstadosResponseDto
    {
        public int IdServicio { get; set; }
        public int IdEstado { get; set; }
        public int MyProperty { get; set; }
        public KmmpConductorResponseDto Conductor { get; set; } = new();
        public KmmpAutomovilResponseDto Automovil { get; set; } = new();
        public KmmpServicioDetalleResponseDto ServicioDetalle { get; set; } = new();
        public KmmpGastoAdicionalResponseDto GastoAdicional { get; set; } = new();
        public List<KmmpDestinoResponseDto> ListaDestino { get; set; } = new();
    }
}
