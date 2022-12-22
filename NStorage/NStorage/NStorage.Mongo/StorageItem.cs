namespace NStorage.Mongo;

public class StorageItem
{
    public string Id { get; set; }
    public string Value { get; set; }

    public StorageItem(string id, string value)
    {
        Id = id;
        Value = value;
    }
}