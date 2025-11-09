using AutoAlquila.Application.Abstractions.Clock;
using AutoAlquila.Application.Abstractions.Data;
using AutoAlquila.Application.Abstractions.Email;
using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Pruebas;
using AutoAlquila.Domain.Usuarios;
using AutoAlquila.Domain.Vehiculos;
using AutoAlquila.Infraestructure.Clock;
using AutoAlquila.Infraestructure.Data;
using AutoAlquila.Infraestructure.Email;
using AutoAlquila.Infraestructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoAlquila.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUsuarioRepositorio, UsuarioRepository>();
            services.AddScoped<IVehiculoRepositorio, VehiculoRepository>();
            services.AddScoped<IAlquilerRepository, AlquilerRepository>();
            services.AddScoped<IPruebaRepository, PruebaRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            //AQUI REGISTRAMOS EL MAPEO PAR PARSEAR
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandle());
            return services;
        }
    }
}
