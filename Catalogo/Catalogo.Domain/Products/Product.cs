using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products
{
    public sealed class Product : Entity
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Descripcion { get; set; }
        public string? ImageUrl { get; set; }
        public string? Code { get; set; }

        private Product(Guid id, string name, decimal price, string descripcion, string imageUrl, string code) : base(id)
        {
            Name = name;
            Price = price;
            Descripcion = descripcion;
            ImageUrl = imageUrl;
            Code = code;
        }

        public static Product Create(string name, decimal price, string descripcion, string imageUrl, string code)
        {
            var product = new Product(Guid.NewGuid(), name, price, descripcion, imageUrl, code);
            var productDomainEvent = new ProductCreatedDomainEvent(product.Id);
            product.RaiseDomainEvents(productDomainEvent);  
            return product;
        }
    }
}
