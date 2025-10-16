using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Catalogo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogoDbContext>(opt =>
            {
                opt.LogTo(Console.WriteLine, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                }, LogLevel.Information).EnableSensitiveDataLogging();
                opt.UseSqlServer(configuration.GetConnectionString("CatalogoConnectionString")).UseSnakeCaseNamingConvention();
            });
            return services;
        }
    }
}
