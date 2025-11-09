using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Shared;
using AutoAlquila.Domain.Usuarios;
using AutoAlquila.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAlquila.Infraestructure.Configurations
{
    internal sealed class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
    {
        public void Configure(EntityTypeBuilder<Alquiler> builder)
        {
            builder.ToTable("alquileres");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.PrecioPorPeriodo, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(x => x.Mantenimiento, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(x => x.Accesorios, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(x => x.PrecioTotal, pb =>
            {
                pb.Property(m => m.tipoMoneda).HasConversion(tm => tm.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(x => x.Duracion);

            //Relacion de uno a muchos
            builder.HasOne<Vehiculo>().WithMany().HasForeignKey(x => x.VehiculoId);
            builder.HasOne<Usuario>().WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
