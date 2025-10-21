namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ClienteDto
    {
        public required int TipoDocumentoCliente { get; set; }     // 1 = DNI, 2 = CE, 3 = RUC, 4 = Pasaporte
        public required string NumeroDocumentoCliente { get; set; }
        public required string NombreCliente { get; set; }
        public required string ApellidosCliente { get; set; }
        public required string Telefono { get; set; }
        public string? CodigoCentroCosto { get; set; }
        public bool Negociado { get; set; }
    }
}
