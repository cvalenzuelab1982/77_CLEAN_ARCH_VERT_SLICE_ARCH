using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Segurirdad
{
    public class ValidacionLoginRequestDto
    {
        [Required]
        public string Usuario { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public int Aplicacion { get; set; }
    }
}
