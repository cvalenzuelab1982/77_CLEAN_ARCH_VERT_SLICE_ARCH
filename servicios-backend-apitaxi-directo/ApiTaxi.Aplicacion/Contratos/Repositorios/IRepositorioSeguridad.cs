using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;

namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioSeguridad
    {
        Task<ValidacionLoginResponseDto> Autenticar(ConsultarValidacionLogin request);
    }
}
