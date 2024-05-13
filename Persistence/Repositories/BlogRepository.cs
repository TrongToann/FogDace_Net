using Domain.Abstraction.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog, Guid>, IBlogRepository
    {
        private readonly DBContext _dbContext;  
        public BlogRepository(DBContext context) : base(context)
        {
            _dbContext = context;
        }
        public override async Task<Blog> FindByIdAsync(Guid id, CancellationToken cancellationToken = default,
            params Expression<Func<Blog, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public override async Task<Blog> FindSingleAsync(Expression<Func<Blog, bool>> predicate,
            CancellationToken cancellationToken = default,
            params Expression<Func<Blog, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0)
                .SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
