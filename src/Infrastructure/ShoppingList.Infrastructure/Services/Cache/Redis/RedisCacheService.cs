using Microsoft.Extensions.Caching.Distributed;
using ShoppingList.Domain.Common;
using ShoppingList.Infrastructure.Services.Cache;

namespace ShoppingList.Infrastructure.Services.Cache.Redis
{
    public class RedisCacheService : IBaseCache
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CreateAsync(string cacheName, byte[] data)
        {
            await _distributedCache.SetAsync(cacheName, data);
        }

        public async Task DeleteAsync(string cacheName)
        {
            await _distributedCache.RemoveAsync(cacheName);
        }

        public async Task<byte[]> GetAsync(string cacheName)
        {
            return await _distributedCache.GetAsync(cacheName);
        }
    }
}
