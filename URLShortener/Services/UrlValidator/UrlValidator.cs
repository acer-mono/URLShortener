using System;

namespace URLShortener.Services.UrlValidator
{
    public class UrlValidator : IUrlValidator
    {
        public bool IsValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }
    }
}