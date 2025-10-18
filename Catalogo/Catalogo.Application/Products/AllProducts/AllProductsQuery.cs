using Catalogo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Catalogo.Application.Products.AllProducts
{
    public sealed class AllProductsQuery : IRequest<List<ProductDTO>>
    {
        public HttpContext? Context { get; set; }
    }
}
