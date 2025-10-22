using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class DestinoRequestDto
    {
        [Required]
        public decimal LatitudOrigen { get; set; }

        [Required]
        public decimal LongitudOrigen { get; set; }

        [Required]
        public decimal LatitudDestino { get; set; }

        [Required]
        public decimal LongitudDestino { get; set; }

        [Required]
        public string DireccionOrigen { get; set; } = null!;

        [Required]
        public int NumeroDireccionOrigen { get; set; }

        [Required]
        public string DireccionDestino { get; set; } = null!;

        [Required]
        public int NumeroDireccionDestino { get; set; }

        [Required]
        public int Orden { get; set; }

        [Required]
        public decimal DistanciaDestinoKilometro { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string FechaInicio { get; set; } = null!;

        public string FechaFin { get; set; } = null!;

        [Required]
        public string ZonaOrigen { get; set; } = null!;

        [Required]
        public string ZonaDestino { get; set; } = null!;

        [Required]
        public bool Negociado { get; set; }
    }
}
