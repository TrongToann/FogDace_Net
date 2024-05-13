namespace Infrastructure.Redis
{
    public interface IResponeCacheService
    {
        Task SetCacheResponeAsync(string cacheKey, object respone, TimeSpan timeOut);
        Task<String> GetCacheResponeAsync(string cacheKey);
        Task RemoveCacheResponeAsync(string pattern);
    }
}
