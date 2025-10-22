using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio
{
    public class CasoDeUsoCancelarServicio : IRequestHandler<CmdCancelarServicio, ServicioCancelarResponseDto>
    {
        private readonly IRepositorioServicios _Repositorio;

        public CasoDeUsoCancelarServicio(IRepositorioServicios repositorio)
        {
            _Repositorio = repositorio;
        }

        public async Task<ServicioCancelarResponseDto> Handle(CmdCancelarServicio request)
        {
            var servicio = await _Repositorio.CancelarServicio(request);
            if (servicio is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return servicio;
        }
    }
}
