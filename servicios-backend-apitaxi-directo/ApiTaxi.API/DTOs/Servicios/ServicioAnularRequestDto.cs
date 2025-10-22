using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Servicios
{
    public class ServicioAnularRequestDto
    {
        [Required]
        public int IdServicio { get; set; }

        [Required]
        public string MotivoAnulacion { get; set; } = null!;
    }
}
