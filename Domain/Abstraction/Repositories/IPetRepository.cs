using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Abstraction.Repositories
{
    public interface IPetRepository : IGenericRepository<Pet, Guid>
    {
        Task<IEnumerable<Pet>> GetPublishedPetsByAccount(Guid Account_id, params Expression<Func<Pet, object>>[] includeProperties);
        Task<IEnumerable<Pet>> GetDraftPetsByAccount(Guid Account_id, params Expression<Func<Pet, object>>[] includeProperties);
    }
}
