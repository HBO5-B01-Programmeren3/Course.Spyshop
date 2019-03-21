using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Course.Spyshop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult SearchByName(string productName)
        {
            ViewData["SearchMethod"] = "Opgezocht via tekst";
            ViewData["SearchSubject"] = productName;
            return View("SearchResults");
        }

        public IActionResult SearchById(long id)
        {
            ViewData["SearchMethod"] = "Opgezocht via id nummer";
            ViewData["SearchSubject"] = id;
            return View("SearchResults");
        }
    }
}