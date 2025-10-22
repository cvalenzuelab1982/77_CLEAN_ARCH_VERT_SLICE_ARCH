namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ConductorResponseDto
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
