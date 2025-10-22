namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class AutomovilResponseDto
    {
        public int ID { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public byte[] Foto { get; set; } = null!;
        public int CantidadPasajeros { get; set; }

    }
}
