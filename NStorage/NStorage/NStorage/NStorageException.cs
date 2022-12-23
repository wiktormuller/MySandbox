namespace NStorage;

public abstract class NStorageException : Exception
{
    protected NStorageException(string message) : base(message)
    {
        
    }
}