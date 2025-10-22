using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Tarifarios;

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
    [StringLength(250)]
    public string DireccionOrigen { get; set; } = null!;

    [Required]
    public int NumeroDireccionOrigen { get; set; }

    [Required]
    public string DireccionDestino { get; set; } = null!;

    [Required]
    public int NumeroDireccionDestino { get; set; }

    [Required]
    public int Orden { get; set; }
 
}
