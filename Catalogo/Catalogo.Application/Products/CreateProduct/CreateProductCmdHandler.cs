using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.CreateProduct
{
    internal sealed class CreateProductCmdHandler : IRequestHandler<CreateProductCmd, Guid>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCmdHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCmd request, CancellationToken cancellationToken)
        {
            var productNew = Product.Create(request.Name, request.Price, request.Description, null!, null!, request.CategoryId);
            _repository.Add(productNew);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return productNew.Id;
        }
    }
}
