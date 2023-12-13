using AirBnb.Server.App.Domain.Common.Caching;

namespace AirBnb.Server.App.Persistence.Caching;

public interface ICacheBroker
{
    ValueTask<T?> GetAsync<T>(string key);

    ValueTask<bool> TryGetAsync<T>(string key, out T? value);

    ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions = default);

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default);

    ValueTask DeleteAsync(string key);
}