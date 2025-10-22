using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ServicioAnularResponseDto
    {
        public string Mensaje { get; set; } = null!;
        public bool Confirmación { get; set; }
    }
}
