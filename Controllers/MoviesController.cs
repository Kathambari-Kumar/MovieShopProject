using Microsoft.AspNetCore.Mvc;
using MovieShop.Models.Db;
using MovieShop.Services;
namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieServices  _movieService;
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
        public IActionResult Create(Movie movie)
        {
            if (movie == null)
            {

                return BadRequest("Invalid movie data");

            }

            _movieService.Create(movie);


            return View(movie);
        }
        public IActionResult Details() 
        { 
            return View();
        }

    }
}
