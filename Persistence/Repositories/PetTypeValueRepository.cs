using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PetTypeValueRepository : GenericRepository<PetTypeValue, Guid>, IPetTypeValueRepository
    {
        private readonly DBContext _context;
        public PetTypeValueRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
