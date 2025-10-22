using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Execpciones;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio
{
    public class CasoDeUsoAnularServicio : IRequestHandler<CmdAnularServicio, ServicioAnularResponseDto>
    {
        private readonly IRepositorioServicios _Repositorio;

        public CasoDeUsoAnularServicio(IRepositorioServicios repositorio)
        {
            _Repositorio = repositorio;
        }

        public async Task<ServicioAnularResponseDto> Handle(CmdAnularServicio request)
        {
            var servicio = await _Repositorio.AnularServicio(request);
            if (servicio is null) {
                throw new ExcepcionNoEncontrado();
            }

            return servicio;
        }
    }
}
