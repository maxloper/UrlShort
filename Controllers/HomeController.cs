using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UrlShortshort.Controllers;
using UrlShort.AppDbcontext;
using UrlShort.Models;

namespace UrlShortshort.Controllers
{
    public class HomeController : Controller
    {


        // DB context
        private readonly ApplicationDbContext _db;


        // the allowed letters from a string picked at random for the short url
        const string allowedUrlString = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";


        // Dependency injection for the Db context

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        // converters the Long url to a random shorter URL
        public ActionResult GenarateShortURL(string longUrl)
        {

            var code = GenerateCode();


            while (_db.UrlDetails.ToList().Any(x => x.ShortUrl== code))
            {
                code = GenerateCode();
            }

            var url = new UrlDetail()
            {
                LongUrl = longUrl,
                ShortUrl = code
            };
            ViewBag.Nurl = url;
            _db.UrlDetails.Add(url);
            _db.SaveChanges();
            return Json(new {url});
        }

        // converts the long url string to a random string using the urlSafe

        public string GenerateCode()
        {
            return allowedUrlString.Substring(new Random().Next(0, allowedUrlString.Length), new Random().Next(2, 6));
        }
    }
}
