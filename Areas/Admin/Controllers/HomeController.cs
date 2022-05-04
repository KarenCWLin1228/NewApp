using Microsoft.AspNetCore.Mvc;
//using NewLibrary;

namespace Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewBag.Str = "";

            return View();
        }
    }
}