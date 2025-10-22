using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;

namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioTarifario
    {
        Task<TarifarioDto> ObtenerTarifario(ConsultaObtenerTarifario request);
    }
}
