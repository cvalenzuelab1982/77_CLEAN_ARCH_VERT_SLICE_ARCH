using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Comandos.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;

namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioSeguridad
    {
        Task<string> Autenticar(CmdValidacionLogin request);
    }
}
