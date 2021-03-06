using System;

namespace Equinor.Lighthouse.Api.Infrastructure.Caching;

public interface ICacheManager
{
    T Get<T>(string key) where T : class;
    void Remove(string key);
    T GetOrCreate<T>(string key, Func<T> fetch, CacheDuration duration, long expiration) where T : class;
}