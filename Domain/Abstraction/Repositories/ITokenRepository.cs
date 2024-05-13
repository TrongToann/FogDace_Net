using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token, Guid>
    {
    }
}
