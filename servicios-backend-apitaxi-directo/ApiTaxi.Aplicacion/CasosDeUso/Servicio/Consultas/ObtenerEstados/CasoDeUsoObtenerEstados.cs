using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados
{
    public class CasoDeUsoObtenerEstados : IRequestHandler<ConsultaObtenerEstados, EstadoDto>
    {
        private readonly IRepositorioServicios _repositorio;

        public CasoDeUsoObtenerEstados(IRepositorioServicios repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<EstadoDto> Handle(ConsultaObtenerEstados request)
        {
            var estado = await _repositorio.ObtenerEstado(request);
            if (estado is null) {
                throw new ExcepcionNoEncontrado();
            }

            return estado;
        }
    }
}
