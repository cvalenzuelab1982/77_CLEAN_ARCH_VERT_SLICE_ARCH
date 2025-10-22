using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin;
using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        public RepositorioSeguridad()
        {

        }

        public Task<ValidacionLoginResponseDto> Autenticar(ConsultarValidacionLogin request)
        {
            throw new NotImplementedException();
        }
    }
}
