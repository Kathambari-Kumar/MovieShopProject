using Microsoft.AspNetCore.Mvc;

namespace MovieShop.wwwroot
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
