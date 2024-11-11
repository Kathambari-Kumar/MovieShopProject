using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display()

        {
            return View();
        }


    }
}
