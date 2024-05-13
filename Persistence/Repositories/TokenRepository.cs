using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class TokenRepository : GenericRepository<Token, Guid>, ITokenRepository
    {
        private readonly DBContext _context;

        public TokenRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
