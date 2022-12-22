using System.Text.Json;
using MongoDB.Driver;

namespace NStorage.Mongo;

internal sealed class MongoStorage : IStorage
{
    private readonly IMongoCollection<StorageItem> _collection;

    public MongoStorage(IMongoDatabase database)
    {
        _collection = database.GetCollection<StorageItem>("items");
    }

    public Task<object> GetAsync(string key) => GetAsync<object>(key);

    public async Task<T> GetAsync<T>(string key)
    {
        var cursor = await _collection.FindAsync(x => x.Id == key).ConfigureAwait(false);
        var item = await cursor.SingleOrDefaultAsync().ConfigureAwait(false);;

        if (item is null)
        {
            return default;
        }

        if (string.IsNullOrWhiteSpace(item.Value))
        {
            return default;
        }

        var data = JsonSerializer.Deserialize<T>(item.Value);

        return data;
    }

    public async Task SetASync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await _collection.ReplaceOneAsync(x => x.Id == key, new StorageItem(key, json), new ReplaceOptions
        {
            IsUpsert = true
        }).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string key) 
        => await _collection.DeleteOneAsync(x => x.Id == key).ConfigureAwait(false);
}