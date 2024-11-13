using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;
using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;
using MovieShop.Services;
using System.Diagnostics;

namespace MovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieServices _movieServices;
        

        public HomeController(ILogger<HomeController> logger,IMovieServices movieServices)
        {
            _logger = logger;
            _movieServices = movieServices;

        }

        public IActionResult Index()
        {
            var listOfTop5Newest =_movieServices.Top5Newest();

            var listOfTop5Oldest = _movieServices.Top5Oldest();

            var listOfTop5Cheapest = _movieServices.Top5Cheapest();

            var model = new MoviesVM
            {
                Top5Newest = listOfTop5Newest,
                Top5Oldet = listOfTop5Oldest,
                Top5Cheapest = listOfTop5Cheapest


            };

            return View(model);
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
