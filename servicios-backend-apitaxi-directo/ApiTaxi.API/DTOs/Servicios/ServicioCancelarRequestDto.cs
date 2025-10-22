using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class ServicioCancelarRequestDto
    {
        [Required]
        public int IdServicio { get; set; }

        [Required]
        public string MotivoCancelacion { get; set; } = null!;
    }
}
