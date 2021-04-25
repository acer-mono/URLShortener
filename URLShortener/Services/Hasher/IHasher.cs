namespace URLShortener.Services.Hasher
{
    public interface IHasher
    {
        string Hash(string data);
    }
}