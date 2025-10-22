using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin
{
    public class ConsultarValidacionLogin : IRequest<ValidacionLoginResponseDto>
    {
        public required string Usuario { get; set; }
        public required string Password { get; set; }
        public required int Aplicacion { get; set; }
    }
}
