using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorisTarifario : IRepositorioTarifario
    {
        public RepositorisTarifario()
        {

        }

        public async Task<TarifarioDto> ObtenerTarifario(ConsultaObtenerTarifario request)
        {
            throw new NotImplementedException();
        }
    }
}
