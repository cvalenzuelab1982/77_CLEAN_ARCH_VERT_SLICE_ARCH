using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion
{
    public class CasoDeUsoObtenerServicioInformacion : IRequestHandler<ConsultaObtenerServicioInformacion, ServicioInformacionResponseDto>
    {
        private readonly IRepositorioServicios _repositorio;

        public CasoDeUsoObtenerServicioInformacion(IRepositorioServicios repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ServicioInformacionResponseDto> Handle(ConsultaObtenerServicioInformacion request)
        {
            var informacion = await _repositorio.ObtenerServicioInformacion(request);
            if (informacion is null) 
            {
                throw new ExcepcionNoEncontrado();
            }

            return informacion; 
        }
    }
}
