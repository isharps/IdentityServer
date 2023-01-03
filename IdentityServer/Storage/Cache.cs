﻿using IdentityServer.Serialization;
using Microsoft.Extensions.Caching.Distributed;

namespace IdentityServer.Storage
{
    internal class Cache : ICache
    {
        private readonly IDistributedCache _distributedCache;

        public Cache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task SetAsync(string key, object value, TimeSpan timeSpan)
        {
            var json = ObjectSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, json, new DistributedCacheEntryOptions
            {
                SlidingExpiration = timeSpan,
            });
        }

        public async Task RevomeAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(json))
            {
                return default;
            }
            return ObjectSerializer.Deserialize<T>(json);
        }
    }
}
