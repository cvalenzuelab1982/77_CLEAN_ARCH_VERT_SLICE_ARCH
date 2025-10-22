using ApiTaxi.Persistencia.Repositorios;
using ApiTaxi.Aplicacion.Contratos.Persistencia;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTaxi.Persistencia
{
    public static class RegistroDeServiciosDePersistencia
    {
        public static IServiceCollection AgregarServicioDePersistencia(this IServiceCollection services)
        {
            services.AddDbContext<ApitaxiDbContext>(opt => opt.UseSqlServer("name=ApitaxiConnectionString"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositorioServicios, RepositorioServicios>();
            services.AddScoped<IRepositorioTarifario, RepositorisTarifario>();

            return services;
        }
    }
}
