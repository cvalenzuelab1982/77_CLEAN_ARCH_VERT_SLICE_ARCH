using AutoAlquila.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAlquila.Infraestructure.Configurations
{
    internal sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(200).HasConversion(n => n!.Value, value => new Nombre(value));
            builder.Property(x => x.Apellido).HasMaxLength(200).HasConversion(ap => ap!.Value, value => new Apellido(value));
            builder.Property(x => x.Email).HasMaxLength(400).HasConversion(e => e!.Value, value => new Domain.Usuarios.Email(value));
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
