using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface IProductRepository : IGenericRepository<Product, Guid>
    {
    }
}
