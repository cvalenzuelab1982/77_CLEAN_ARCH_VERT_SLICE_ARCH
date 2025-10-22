using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ServicioCancelarResponseDto
    {
        public string CodigoCentroCosto { get; set; } = null!;
        public bool Confirmacion { get; set; }
    }
}
