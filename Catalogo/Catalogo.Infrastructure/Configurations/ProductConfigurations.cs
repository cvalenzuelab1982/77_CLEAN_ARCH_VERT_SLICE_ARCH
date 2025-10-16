using Catalogo.Domain.Categories;
using Catalogo.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.Configurations
{
    internal sealed class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(p => p.Id);

            //Un producto tiene una sola categoria
            builder.HasOne<Category>();

            //Una categoria tiene muchos productos
            builder.HasOne<Category>().WithMany().HasForeignKey(c => c.CategoryId);
        }
    }
}
