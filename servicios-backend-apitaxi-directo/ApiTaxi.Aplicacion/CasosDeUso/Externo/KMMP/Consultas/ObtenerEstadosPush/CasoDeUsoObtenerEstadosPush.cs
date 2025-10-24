using ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Consultas.ObtenerEstadosPush
{
    public class CasoDeUsoObtenerEstadosPush : IRequestHandler<ConsultaObtenerEstadosPush, KmmpEstadosResponseDto>
    {
        private readonly IRepositorioKMMPServicio _repositorio;

        public CasoDeUsoObtenerEstadosPush(IRepositorioKMMPServicio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<KmmpEstadosResponseDto> Handle(ConsultaObtenerEstadosPush request)
        {
            var estado = await _repositorio.ObtenerEstadosPush();
            if (estado == null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return estado;
        }
    }
}
