using Infrastructure;
using Infrastructure.Redis;
using StackExchange.Redis;

namespace API.Installer
{
    public class CacheInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);
            service.AddSingleton(redisConfiguration);
            if(!redisConfiguration.Enabled)
                return;
            service.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            service.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
            service.AddSingleton<IResponeCacheService, ResponeCacheService>();
        }
    }
}
