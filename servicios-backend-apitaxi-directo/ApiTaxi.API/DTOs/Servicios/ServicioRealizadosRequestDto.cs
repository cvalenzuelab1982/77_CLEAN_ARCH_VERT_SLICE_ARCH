using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class ServicioRealizadosRequestDto
    {
        [Required]
        public int TipoDocumentoCliente { get; set; }

        [Required]
        public string NumeroDocumentoCliente { get; set; } = null!;

        [Required]
        public string Ruc { get; set; } = null!;
    }
}
