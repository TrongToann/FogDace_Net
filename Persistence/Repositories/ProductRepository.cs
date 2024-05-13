using Domain.Abstraction.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product, Guid>, IProductRepository
    {
        private readonly DBContext _dbContext;
        public ProductRepository(DBContext context) : base(context)
        {
            _dbContext = context;
        }
        public override async Task<Product> FindByIdAsync(Guid id, CancellationToken cancellationToken = default,
            params Expression<Func<Product, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public override async Task<Product> FindSingleAsync(Expression<Func<Product, bool>> predicate,
            CancellationToken cancellationToken = default,
            params Expression<Func<Product, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0)
                .SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
