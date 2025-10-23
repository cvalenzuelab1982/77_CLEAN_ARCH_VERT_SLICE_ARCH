using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Comandos.ObtenerLogin
{
    public class CmdValidacionLogin : IRequest<TokenResponseDto>
    {
        public required string Usuario { get; set; }
        public required string Password { get; set; }
        public required int Aplicacion { get; set; }
    }
}
