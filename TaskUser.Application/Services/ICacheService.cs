using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Application.Services
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);
        bool Set<T>(string cacheKey, T value);
        bool Set<T>(string cacheKey, T value, TimeSpan expire);
        void Clear();
        void RemoveByPrefix(string prefix);
    }
}
