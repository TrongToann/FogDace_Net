using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PetTypeRepository : GenericRepository<PetType, Guid>, IPetTypeRepository
    {
        private readonly DBContext _context;
        public PetTypeRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
