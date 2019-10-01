using System.Diagnostics;
using Church_Finder.Models;
using Church_Finder.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Church_Finder.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocationService _service;

        public HomeController(LocationService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Religions = new SelectList(_service.getReligionsList());
            ViewBag.MembersOptions = new SelectList(new string[] { "0-100", "100-300", "300-500", "500+" });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
