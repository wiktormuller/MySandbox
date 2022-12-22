using System.Collections.Concurrent;

namespace NStorage.InMemory;

internal sealed class InMemoryStorage : IStorage
{
    private readonly ConcurrentDictionary<string, object> _storage = new();

    public Task<object> GetAsync(string key) => GetAsync<object>(key);

    public Task<T> GetAsync<T>(string key)
    {
        if (_storage.TryGetValue(key, out var value))
        {
            return Task.FromResult((T)value);
        }

        return Task.FromResult<T>(default);
    }

    public Task SetASync<T>(string key, T value)
    {
        _storage.AddOrUpdate(key, _ => value, (_, _) => value);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string key)
    {
        _storage.TryRemove(key, out _);
        return Task.CompletedTask;
    }
}