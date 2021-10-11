using Microsoft.Extensions.Caching.Memory;
using System;

namespace Aop.AspnetCore
{
    public class MemoryProvider : ICacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public void Set<T>(string key, T value, TimeSpan? expireTimeSpan = null)
        {
            if (expireTimeSpan.HasValue)
                _memoryCache.Set(key, value, expireTimeSpan.Value);
            else
            {
                _memoryCache.Set(key, value);
            }
        }
    }
}
