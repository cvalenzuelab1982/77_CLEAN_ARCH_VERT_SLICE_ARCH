using ApiTaxi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTaxi.Persistencia.Configuraciones
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            //Configura aqui las propiedades de tu table que sera creada desde codigo C# a la DB
            //builder.Property(prop => prop.Ruc).HasMaxLength(20).IsRequired();
        }
    }
}
