namespace NStorage.Mongo;

public class MissingMongoStorageOptionsException : NStorageException
{
    public MissingMongoStorageOptionsException() : base("Mongo storage options are missing.")
    {
    }
}