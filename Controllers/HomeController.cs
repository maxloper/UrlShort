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

        const string urlsafe = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";


        // DI for the Db context

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

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
            return urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
        }
    }
}
