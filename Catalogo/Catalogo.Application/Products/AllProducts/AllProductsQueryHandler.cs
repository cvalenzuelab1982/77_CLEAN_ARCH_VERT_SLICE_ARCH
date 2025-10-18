using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.AllProducts
{
    internal sealed class AllProductsQueryHandler : IRequestHandler<AllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public AllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            return products.ConvertAll(p => p.ToDTO(request.Context!));
        }
    }
}
