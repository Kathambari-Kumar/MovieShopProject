using Microsoft.AspNetCore.Mvc;
using MovieShop.Models.Db;
using MovieShop.Services;
namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieServices _movieService;
        private readonly ICustomerServices _customerService;

        public MoviesController(IMovieServices movieService, ICustomerServices customerService)
        {
            _movieService = movieService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieService.Create(movie);


            return View(movie);
        }
        public IActionResult Details() 
        {
            var movielist=_movieService.Display();
            return View(movielist);
        }
    }
}
