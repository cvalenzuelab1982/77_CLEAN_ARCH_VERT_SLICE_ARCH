using System.ComponentModel.DataAnnotations;

namespace ApiTaxi.API.DTOs.Tarifarios
{
    public class TarifarioRequestDto
    {
        [Required]
        public List<DestinoRequestDto> ListaDestinos { get; set; } = new();

        [Required]
        public int IdTipoServicio { get; set; }

        [Required]
        public int IdTipoPago { get; set; }
    }
}
