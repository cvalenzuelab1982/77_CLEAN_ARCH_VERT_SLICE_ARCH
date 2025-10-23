using ApiTaxi.Persistencia.Repositorios;
using ApiTaxi.Aplicacion.Contratos.Persistencia;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiTaxi.Persistencia.Utilidades;
using ApiTaxi.Persistencia.Servicios.Seguridad;
using ApiTaxi.Persistence.Servicios.Seguridad;
using ApiTaxi.Persistencia.Servicios.Red;
using ApiTaxi.Persistencia.Servicios.Sistema;

namespace ApiTaxi.Persistencia
{
    public static class RegistroDeServiciosDePersistencia
    {
        public static IServiceCollection AgregarServicioDePersistencia(this IServiceCollection services)
        {
            services.AddDbContext<ApitaxiDbContext>(opt => opt.UseSqlServer("name=ApitaxiConnectionString"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IEncripta, Encripta>();
            services.AddSingleton<INetworkHelper, NetworkHelper>();
            services.AddSingleton<IVersionServicio, VersionServicio>();
            services.AddScoped<IRepositorioSeguridad, RepositorioSeguridad>();
            services.AddScoped<IRepositorioServicios, RepositorioServicios>();
            services.AddScoped<IRepositorioTarifario, RepositorisTarifario>();

            return services;
        }
    }
}
