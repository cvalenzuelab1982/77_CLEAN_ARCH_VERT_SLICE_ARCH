using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados
{
    public class CasoDeUsoObtenerServiciosRealizados : IRequestHandler<ConsultaObtenerServiciosRealizados, List<ServicioRealizadoResponseDto>>
    {
        private readonly IRepositorioServicios _repositorio;

        public CasoDeUsoObtenerServiciosRealizados(IRepositorioServicios repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ServicioRealizadoResponseDto>> Handle(ConsultaObtenerServiciosRealizados request)
        {
            var realizados = await _repositorio.ObtenerServiciosRealizados(request);
            if (realizados is null) 
            {
                throw new ExcepcionNoEncontrado();
            }

            return realizados;
        }
    }
}
