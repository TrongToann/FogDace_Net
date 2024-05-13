using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class TokenUsedRepository : GenericRepository<TokenUsed, Guid>, ITokenUsedRepository
    {
        private readonly DBContext _context;
        public TokenUsedRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
