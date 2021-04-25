namespace URLShortener.Services.UrlValidator
{
    public interface IUrlValidator
    {
        bool IsValid(string url);
    }
}