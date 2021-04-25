using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private const string ShortenUrlEndpoint = "/shorten";
        private readonly DatabaseContext _dbContext;

        public HomeController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewData["endpoint"] = ShortenUrlEndpoint;
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [Route("/shorten")]
        public IActionResult Shorten([Bind("Url")] ShortenUrlRequest request)
        {
            var result = _dbContext.Urls.FirstOrDefault(u => u.OriginalUrl.Equals(request.Url));

            if (!IsUrlValid(request.Url))
            {
                return BadRequest(new {title = "Bad request", message = "URL is not valid"});
            }

            if (result == null)
            {
                var hash = CreateUniqueHash(request.Url);
                result = new Url {OriginalUrl = request.Url, Hash = hash};
                _dbContext.Urls.Add(result);
                _dbContext.SaveChanges();
            }

            var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{result.Hash}";

            return Json(new {url});
        }

        [Route("/{slug}")]
        public IActionResult Search(string slug)
        {
            var result = _dbContext.Urls.FirstOrDefault(u => u.Hash.Equals(slug));

            if (result != null)
            {
                return Redirect(result.OriginalUrl);
            }
            
            return View("Error404");
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private string CreateUniqueHash(string data)
        {
            //TODO to services -> Hasher
            using SHA1Managed sha1 = new SHA1Managed();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(data));
            return string.Concat(Convert.ToBase64String(hash).ToCharArray().Where(x => char.IsLetterOrDigit(x))
                .Take(10));
        }

        private bool IsUrlValid(string source)
        {
            //TODO validator change and to services!!!!!
            return Uri.TryCreate(source, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }
    }
}