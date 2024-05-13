using Application.Data;
using Domain.Abstraction.Repositories;
using Persistence.Extension;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<DatabaseOptionSetup>();
            services.AddDbContext<DBContext>(
                (serviceProvider, dbContextOptionBuilder) =>
                {
                    var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
                    dbContextOptionBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
                    {
                        sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                        sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
                    });
                    dbContextOptionBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                    dbContextOptionBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                });

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            //services.AddScoped<IUnitOfWork>(sp =>
            //    sp.GetRequiredService<DBContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApplicationDBContext>(sp =>
                sp.GetRequiredService<DBContext>());
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenUsedRepository, TokenUsedRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeValueRepository, PetTypeValueRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
