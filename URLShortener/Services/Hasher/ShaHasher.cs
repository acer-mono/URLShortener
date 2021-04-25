using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Services.Hasher
{
    public class ShaHasher : IHasher
    {
        public string Hash(string data)
        {
            using SHA1Managed sha1 = new SHA1Managed();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(data));
            return string.Concat(Convert.ToBase64String(hash).ToCharArray().Where(char.IsLetterOrDigit)
                .Take(10));
        }
    }
}