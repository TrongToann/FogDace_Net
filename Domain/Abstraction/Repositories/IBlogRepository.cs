using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog, Guid>
    {
    }
}
