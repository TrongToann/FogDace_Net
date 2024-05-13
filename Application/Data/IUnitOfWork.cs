using Domain.Abstraction.Repositories;
using Domain.Abstraction;

namespace Application.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : EntityBase<TKey>;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(Guid Account_id);
    }
}
