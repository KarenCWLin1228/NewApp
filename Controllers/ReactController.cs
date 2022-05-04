using Microsoft.AspNetCore.Mvc;

namespace NewApp.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
