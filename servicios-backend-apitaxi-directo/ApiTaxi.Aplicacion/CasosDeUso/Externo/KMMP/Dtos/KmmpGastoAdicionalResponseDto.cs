namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpGastoAdicionalResponseDto
    {
        public int IdConcepto { get; set; }
        public KmmpConceptoResponseDto Concepto { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Observacion { get; set; } = null!;
        public decimal TiempoMinuto { get; set; }
    }
}
