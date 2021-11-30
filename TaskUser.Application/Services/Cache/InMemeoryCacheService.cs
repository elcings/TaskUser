using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Application.Services
{
    public class InMemeoryCacheService : ICacheService
    {
        private TimeSpan Expiration => TimeSpan.FromDays(30);
        private static readonly object Sync = new object();

        private static MemoryCache Cache =>  MemoryCache.Default;

     

        public bool TryGet<T>(string cacheKey, out T value)
        {
            lock (Sync)
            {
                value = default;
                if (Cache.Contains(cacheKey))
                {
                    return false;
                }
                if (!(Cache.Get(cacheKey) is T item)) return false;
                value = item;
                return true;
            }
        }

        public bool Set<T>(string cacheKey, T value)
        {
            Set(cacheKey, value, Expiration);
            return true;
        }

        public bool Set<T>(string cacheKey, T value, TimeSpan expire)
        {
            lock (Sync)
            {
                if (Cache.Contains(cacheKey))
                {
                    Cache.Remove(cacheKey);
                }

                Cache.Set(cacheKey, value, DateTime.Now + Expiration);
                return true;
            }
        }

        public void Clear()
        {
            lock (Sync)
            {
                var cacheItems = Cache.ToList();

                foreach (var a in cacheItems)
                {
                    Cache.Remove(a.Key);
                }
            }
        }

        public void RemoveByPrefix(string prefix)
        {
            lock (Sync)
            {
                var keysToRemove =
                    Cache
                        .Where(c => c.Key.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                        .Select(c => c.Key)
                        .ToList();

                foreach (var key in keysToRemove)
                {
                    Cache.Remove(key);
                }
            }
        }
    }
}
