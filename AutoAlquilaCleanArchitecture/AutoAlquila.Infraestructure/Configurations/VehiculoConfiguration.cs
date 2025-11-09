using AutoAlquila.Domain.Shared;
using AutoAlquila.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAlquila.Infraestructure.Configurations
{
    internal sealed class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("vehiculos");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Direccion);
            builder.Property(x => x.Modelo).HasMaxLength(200).HasConversion(x => x!.Value, value =>  new Modelo(value));
            builder.Property(x => x.Vin).HasMaxLength(500).HasConversion(x => x!.Value, value => new Vin(value));
            builder.OwnsOne(x => x.Precio, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, c => TipoMoneda.FromCodigo(c!));
            });
            builder.OwnsOne(x => x.Mantenimiento, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, c => TipoMoneda.FromCodigo(c!));
            });

            builder.Property<byte[]>("Version").IsRowVersion().IsConcurrencyToken();

        }
    }
}
