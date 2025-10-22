using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario
{
    public class CasoDeUsoObtenerTarifario : IRequestHandler<ConsultaObtenerTarifario, TarifarioDto>
    {
        private readonly IRepositorioTarifario _repositorio;

        public CasoDeUsoObtenerTarifario(IRepositorioTarifario repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<TarifarioDto> Handle(ConsultaObtenerTarifario request)
        {
            var tarifario = await _repositorio.ObtenerTarifario(request);
            if (tarifario is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return tarifario;

            //Si usas Mapeadorextensions
            //return consultio.ADto();
        }
    }
}
