using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
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
        private readonly interstellardb _db;

        public HomeController(ILogger<HomeController> logger,IMovieServices movieServices, interstellardb db)
        {
            _logger = logger;
            _movieServices = movieServices;
            _db= db;
        }

        public IActionResult Index()
        {
            var listOfTop5Newest =_movieServices.Top5Newest();

            var listOfTop5Oldest = _movieServices.Top5Oldest();

            var listOfTop5Cheapest = _movieServices.Top5Cheapest();
            var customer = _db.Orders
                         .GroupJoin(_db.OrderRows,
                         or => or.Id,
                         orw => orw.Order.Id,
                         (or, orw) => new TopCustomer
                         {
                             Orderid = or.Customer.Id,
                             Firstname = or.Customer.Firstname,
                             Lastname = or.Customer.Lastname,
                             Price = or.OrderRowList.Sum(r => r.Price)
                         })
                         .OrderByDescending(ce => ce.Price)
                         .Take(1)
                         .SingleOrDefault();

            var movie = _db.Movies
                       .GroupJoin(_db.OrderRows,
                        m => m.Id,
                        orw => orw.Movie.Id,
                        (m, orw) => new PopularMovie
                        {
                            Title = m.Title,
                            orderid = m.OrderRowList
                                        .Select(r => r.Order.Id)
                                        .Count()
                        })
                        .OrderByDescending(r => r.orderid)
                        .Take(1)
                        .SingleOrDefault();
            var model = new MoviesVM
            {
                Top5Newest = listOfTop5Newest,
                Top5Oldet = listOfTop5Oldest,
                Top5Cheapest = listOfTop5Cheapest,
                TopCustomer = customer,
                PopularMovie = movie
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

        [HttpPost]
        public IActionResult PasswordVerification()
        {
            var password = Request.Form["Password"];
            if (password == "#m#k#p")
            {
                return RedirectToAction("MovieMenu","Movies");
            }
            else
            {
                return RedirectToAction("PasswordFailed");
            }
        }
        public IActionResult GetPassword()
        {
            return View();
        }
        public IActionResult PasswordFailed()
        {
            return View();
        }
    }
}
