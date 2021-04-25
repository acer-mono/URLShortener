using System;
using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class Url
    {
        [Required] public string OriginalUrl { get; set; }

        [Required] public string Hash { get; set; }

        public string GetAbsoluteUrl()
        {
            if (OriginalUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                OriginalUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return OriginalUrl;
            }

            return $"http://{OriginalUrl}";
        }
    }
}