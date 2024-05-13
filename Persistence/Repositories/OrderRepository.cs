using Domain.Abstraction.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order, Guid>, IOrderRepository
    {
        private readonly DBContext _dbContext;
        public OrderRepository(DBContext context) : base(context)
        {
            _dbContext = context;
        }
        public override async Task<Order> FindByIdAsync(Guid id, CancellationToken cancellationToken = default,
            params Expression<Func<Order, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_Deleted == 0)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public override async Task<Order> FindSingleAsync(Expression<Func<Order, bool>> predicate,
            CancellationToken cancellationToken = default,
            params Expression<Func<Order, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_Deleted == 0)
                .SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
