using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Pruebas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAlquila.Infraestructure.Configurations
{
    public class PruebaConfiguration : IEntityTypeConfiguration<Prueba>
    {
        public void Configure(EntityTypeBuilder<Prueba> builder)
        {
            builder.ToTable("Prueba");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(150);
        }
    }
}
