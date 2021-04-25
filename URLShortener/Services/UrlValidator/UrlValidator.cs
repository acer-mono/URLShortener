using System;
using System.Text.RegularExpressions;

namespace URLShortener.Services.UrlValidator
{
    public class UrlValidator : IUrlValidator
    {
        private const string Pattern =
            @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        private static readonly Regex ValidUrlRegex =
            new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public bool IsValid(string url) => ValidUrlRegex.IsMatch(url);
    }
}