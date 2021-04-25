using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Models;
using URLShortener.Services.Hasher;
using URLShortener.Services.UrlValidator;

namespace URLShortener.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private const string ShortenUrlEndpoint = "/shorten";
        private readonly DatabaseContext _dbContext;
        private readonly IHasher _hasher;
        private readonly IUrlValidator _urlValidator;

        public HomeController(DatabaseContext dbContext, IHasher hasher, IUrlValidator urlValidator)
        {
            _dbContext = dbContext;
            _hasher = hasher;
            _urlValidator = urlValidator;
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

            if (!_urlValidator.IsValid(request.Url))
            {
                return BadRequest(new {title = "Bad request", message = "URL is not valid"});
            }

            if (result == null)
            {
                var hash = _hasher.Hash(request.Url);
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
                return Redirect(result.GetAbsoluteUrl());
            }

            return View("Error404");
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}