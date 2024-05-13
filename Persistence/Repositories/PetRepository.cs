using Domain.Abstraction.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class PetRepository : GenericRepository<Pet, Guid>, IPetRepository
    {
        private readonly DBContext _context;
        public PetRepository(DBContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<Pet> FindByIdAsync(Guid id, CancellationToken cancellationToken = default,
            params Expression<Func<Pet, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 &&  x.Is_draft == 0 )
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }
        public override async Task<Pet> FindSingleAsync(Expression<Func<Pet, bool>> predicate,
            CancellationToken cancellationToken = default,
            params Expression<Func<Pet, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0)
                .SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<Pet>> GetDraftPetsByAccount(Guid Account_id, params Expression<Func<Pet, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 1 && x.Is_draft == 0 && x.Account_id == Account_id).
                ToListAsync();
        }

        public async Task<IEnumerable<Pet>> GetPublishedPetsByAccount(Guid Account_id , params Expression<Func<Pet, object>>[] includeProperties)
        {
            return await GetAll(includeProperties).Where(x => x.Is_published == 0 && x.Is_draft == 1 && x.Account_id == Account_id).
                ToListAsync();
        }
    }
}
