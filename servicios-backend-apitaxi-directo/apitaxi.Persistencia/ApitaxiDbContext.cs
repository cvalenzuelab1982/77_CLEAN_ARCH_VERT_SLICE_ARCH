using Microsoft.EntityFrameworkCore;

namespace ApiTaxi.Persistencia
{
    public class ApitaxiDbContext : DbContext
    {

        public ApitaxiDbContext(DbContextOptions<ApitaxiDbContext> options) : base(options)
        {
            
        }

        protected ApitaxiDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Todas la configuraciones de la carpeta "Configuraciones"
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApitaxiDbContext).Assembly);
        }

        //Configuracion de tablas, solo si gestionaremos entidades del dominio
        //public DbSet<Servicio> Servicios { get; set; }
    }
}
