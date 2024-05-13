using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account, Guid>, IAccountRepository
    {
        private readonly DBContext _context;
        public AccountRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
