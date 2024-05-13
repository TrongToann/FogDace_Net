

using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order, Guid>
    {
    }
}
