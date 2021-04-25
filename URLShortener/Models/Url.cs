using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class Url
    {
        [Required] public string OriginalUrl { get; set; }

        [Required] public string Hash { get; set; }
    }
}