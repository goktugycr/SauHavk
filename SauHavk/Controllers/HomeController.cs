using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SauHavk.Models;

namespace SauHavk.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();

        public IActionResult Events()
        {
            return RedirectToAction("Index", "Events");
        }

        public IActionResult Gallery() => View();
    }
}
