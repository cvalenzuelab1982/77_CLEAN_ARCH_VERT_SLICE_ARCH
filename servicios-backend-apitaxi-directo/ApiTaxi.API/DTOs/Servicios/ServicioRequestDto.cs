using ApiTaxi.API.DTOs.Servicios;
using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class ServicioRequestDto
    {
        [Required]
        public string Ruc { get; set; } = null!;

        [Required]
        public string FechaServicio { get; set; } = null!;

        [Required]
        public string CodigoCentrocosto { get; set; } = null!;

        public string OrdendeServicio { get; set; } = null!;

        [Required]
        public int IdTipoServicio { get; set; }

        [Required]
        public int IdTipoPago { get; set; }

        [Required]
        public decimal TotalServicio { get; set; }

        [Required]
        public decimal DistanciaKilometro { get; set; }

        [Required]
        public string Observacion { get; set; } = null!;

        [Required]
        public List<DestinoRequestDto> ListaDestino { get; set; } = new();

        [Required]
        public List<ClienteRequestDto> ListaCliente { get; set; } = new();
    }
}
