using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace URLShortener.Models
{
    public class ShortenUrlRequest
    {
        public string Url { get; set; } = "";
    }
}