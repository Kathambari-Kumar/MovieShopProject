using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MovieShop.Data;
using MovieShop.Models.Db;
using MovieShop.Services;
using System.Dynamic;
namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieServices _movieService;
        private readonly ICustomerServices _customerService;
        private readonly interstellardb _db;

        public MoviesController(IMovieServices movieService, ICustomerServices customerService, interstellardb db)
        {
            _movieService = movieService;
            _customerService = customerService;
            _db = db;
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
            var movielist = _movieService.Display();
            return View(movielist);
        }



        public IActionResult Update(Movie movie)
        {
            var movielist = _movieService.Display();
            return View(movielist);
        }

       
       

        public IActionResult GenreBasedMovies(string genre)
        {
            var movies = _movieService.MoviesListGenre(genre);
            return View(movies);
        }

        public IActionResult MovieMenu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _movieService.Editmovie(movie);


            return RedirectToAction("Details");
        }

        public IActionResult UpdateSuccessMessage()
        {
            return View();
        }

        public IActionResult CreateSuccessMessage()
        {
            return View();
        }

        public IActionResult ShowAllOrders()
        {
            var orders = _movieService.GetAllOrders();
            return View(orders);
        }


        public IActionResult List(int length = 6, int page = 1)
        {

            //fetch list of movies

            var moviesList = _movieService.GetPaginatedMovies(length, page);
            ViewBag.Page = page;
            ViewBag.Length = length;
            ViewBag.TotalCount = _db.Movies.Count();

            return View(moviesList);

        }

    }
}
