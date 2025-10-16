using Catalogo.Domain.Products;

namespace Catalogo.Domain.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category?>> GetAll(CancellationToken cancellationToken);
        void Add(Category category);
        Task<Category?> GetByIsAsync(Guid id, CancellationToken cancellationToken);
    }
}
