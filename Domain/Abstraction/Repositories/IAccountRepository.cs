using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account, Guid>
    {
    }
}
