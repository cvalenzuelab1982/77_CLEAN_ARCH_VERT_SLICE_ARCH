using Catalogo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly CatalogoDbContext _dbContext;

        protected Repository(CatalogoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?>GetByIsAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}
