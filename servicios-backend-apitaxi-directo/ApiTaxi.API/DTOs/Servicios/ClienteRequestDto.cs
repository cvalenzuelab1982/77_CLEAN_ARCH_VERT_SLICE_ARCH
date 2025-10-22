using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class ClienteRequestDto
    {
        [Required]
        public int TipoDocumentoCliente { get; set; }

        [Required]
        public string NumeroDocumentoCliente { get; set; } = null!;

        [Required]
        public string NombreCliente { get; set; } = null!;

        [Required]
        public string ApellidosCliente { get; set; } = null!;

        [Required]
        public string Telefono { get; set; } = null!;

        public string CodigoCentroCosto { get; set; } = null!;

        [Required]
        public bool Negociado { get; set; }
    }
}
