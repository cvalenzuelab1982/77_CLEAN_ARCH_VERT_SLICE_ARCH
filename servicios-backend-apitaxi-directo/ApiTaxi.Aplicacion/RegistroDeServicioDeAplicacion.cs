using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Consultas.ObtenerTarifario;
using ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos;
using ApiTaxi.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTaxi.Aplicacion
{
    public static class RegistroDeServicioDeAplicacion
    {
        public static IServiceCollection AgregarServicioDeAplicacion(this IServiceCollection services)
        {
            services.AddTransient<IMediator, MediadorSimple>();
            services.AddScoped<IRequestHandler<CmdCrearServicio, int>, CasoDeUsoCrearServicio>();
            services.AddScoped<IRequestHandler<ConsultaObtenerTarifario, TarifarioDto>, CasoDeUsoObtenerTarifario>();

            return services;
        }
    }
}
