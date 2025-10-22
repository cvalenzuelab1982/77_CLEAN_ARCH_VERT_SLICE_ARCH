using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Consultas.ObtenerLogin
{
    public class CasoDeUsoValidacionLogin : IRequestHandler<ConsultarValidacionLogin, ValidacionLoginResponseDto>
    {
        private readonly IRepositorioSeguridad _repositorio;

        public CasoDeUsoValidacionLogin(IRepositorioSeguridad repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ValidacionLoginResponseDto> Handle(ConsultarValidacionLogin request)
        {
            var consulta = await _repositorio.Autenticar(request);
            if (consulta == null) 
            {
                throw new ExcepcionNoEncontrado();
            }

            return consulta;
        }
    }
}
