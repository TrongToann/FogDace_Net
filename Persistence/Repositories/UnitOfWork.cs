using Application.Data;
using Domain.Abstraction;
using Domain.Abstraction.Repositories;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private readonly Dictionary<Type, object> _repositories;
        public UnitOfWork(DBContext dbContext)
        {
            _context = dbContext;
            _repositories = new Dictionary<Type, object>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : EntityBase<TKey>
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity, TKey>)_repositories[typeof(TEntity)];
            }
            var repository = new GenericRepository<TEntity, TKey>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(Guid Account_id)
        {
            return await _context.SaveChangesAsync(Account_id);
        }
    }
}
