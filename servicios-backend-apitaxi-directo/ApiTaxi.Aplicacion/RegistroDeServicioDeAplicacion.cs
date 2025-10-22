using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.AnularServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CancelarServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerEstados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServicioInformacion;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Consultas.ObtenerServiciosRealizados;
using ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos;
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
            services.AddScoped<IRequestHandler<CmdCrearServicio, ServicioDto>, CasoDeUsoCrearServicio>();
            services.AddScoped<IRequestHandler<CmdCancelarServicio, ServicioCancelarResponseDto>, CasoDeUsoCancelarServicio>();
            services.AddScoped<IRequestHandler<CmdAnularServicio, ServicioAnularResponseDto>, CasoDeUsoAnularServicio>();
            services.AddScoped<IRequestHandler<ConsultaObtenerTarifario, TarifarioDto>, CasoDeUsoObtenerTarifario>();
            services.AddScoped<IRequestHandler<ConsultaObtenerEstados, EstadoDto>, CasoDeUsoObtenerEstados>();
            services.AddScoped<IRequestHandler<ConsultaObtenerServiciosRealizados, List<ServicioRealizadoResponseDto>>, CasoDeUsoObtenerServiciosRealizados>();
            services.AddScoped<IRequestHandler<ConsultaObtenerServicioInformacion, ServicioInformacionResponseDto>, CasoDeUsoObtenerServicioInformacion>();
            return services;
        }
    }
}
