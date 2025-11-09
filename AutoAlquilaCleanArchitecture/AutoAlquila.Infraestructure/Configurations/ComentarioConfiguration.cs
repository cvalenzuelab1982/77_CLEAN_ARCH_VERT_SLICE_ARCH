using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Comentarios;
using AutoAlquila.Domain.Usuarios;
using AutoAlquila.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAlquila.Infraestructure.Configurations
{
    internal sealed class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("comentarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rating).HasConversion(r => r!.Value, value => Rating.Create(value).Value);
            builder.Property(x => x.Descripcion).HasMaxLength(200).HasConversion(c => c.Value, value => new Descripcion(value));

            //Relacion de uno a muchos
            builder.HasOne<Vehiculo>().WithMany().HasForeignKey(x => x.VehiculoId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne<Alquiler>().WithMany().HasForeignKey(x => x.AlquilerId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne<Usuario>().WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
