using Microsoft.AspNetCore.Mvc;

namespace Church_Finder.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}