namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ClienteRequestDto
    {
        public required int TipoDocumentoCliente { get; set; } 
        public required string NumeroDocumentoCliente { get; set; }
        public required string NombreCliente { get; set; }
        public required string ApellidosCliente { get; set; }
        public required string Telefono { get; set; }
        public string CodigoCentroCosto { get; set; } = null!;  
        public bool Negociado { get; set; }
    }
}
