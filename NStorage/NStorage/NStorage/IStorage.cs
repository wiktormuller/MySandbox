namespace NStorage;

public interface IStorage
{
    Task<object> GetAsync(string key);
    Task<T> GetAsync<T>(string key);
    Task SetASync<T>(string key, T value);
    Task DeleteAsync(string key);
}