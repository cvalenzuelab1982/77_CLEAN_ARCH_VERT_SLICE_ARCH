namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos
{
    public class KmmpConductorResponseDto
    {
        public int ID { get; set; }
        public int IdAutomovil { get; set; }
        public decimal Estrellas { get; set; }
        public string Celular { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public byte[] Foto { get; set; } = null!;
    }
}
