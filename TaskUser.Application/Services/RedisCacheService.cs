using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Application.Services
{
    public class RedisCacheService : ICacheService
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void RemoveByPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string cacheKey, T value)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string cacheKey, T value, TimeSpan expire)
        {
            throw new NotImplementedException();
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            throw new NotImplementedException();
        }
    }
}
