using Application.Data;
using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Domain.Entities;
using Domain.Exceptions.Account;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence
{
    public class DBContext : DbContext, IApplicationDBContext, IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetType>()
                    .HasKey(pettype => pettype.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            //New Logic Here
            var result = await base.SaveChangesAsync();
            return result;
        }
        public virtual async Task<int> SaveChangesAsync(Guid Account_id)
        {
            var user = await this.Account.FirstOrDefaultAsync(x => x.Id == Account_id);
            if (user is null) throw new UserNotFound(Account_id);
            foreach (var entry in base.ChangeTracker.Entries<EntityAuditBase<Guid>>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                entry.Entity.ModifiedBy = user.Username;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = user.Username;
                }
            }
            var result = await base.SaveChangesAsync();
            return result;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : EntityBase<TKey>
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity, TKey>)_repositories[typeof(TEntity)];
            }
            var repository = new GenericRepository<TEntity, TKey>(this);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<TokenUsed> TokenUsed { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<PetHealthProfile> PetsHealthProfiles { get; set;}
        public DbSet<TiemPhong> TiemPhong { get; set; }
        public DbSet<TinhCach> TinhCach { get; set; }
        public DbSet<DinhDuong> DinhDuong { get; set; }
        public DbSet<TinhTrangSK> TinhTrangSK { get; set; }
        public DbSet<XoGiun> XoGiun { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PetType> PetType { get; set; }
        public DbSet<PetTypeValue> PetTypeValue { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderShipping> OrderShipping { get; set; }
        public DbSet<OrderProducts> OrderProduct { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

    }
}
