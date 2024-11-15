using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Extensions;
using MovieShop.Models.Db;
using MovieShop.Services;
using Newtonsoft.Json;

namespace MovieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly CartService _cartService;
        private readonly interstellardb _interstellardb;

        public ShoppingCartController(CartService cartService, interstellardb interstellardb)
        {
            _cartService = cartService;
            _interstellardb = interstellardb;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddToCart(int movieId)
        {
            return View();
        }
        [HttpPost, ActionName("AddToCart")]
        public IActionResult AddToShoppingCart(int movieId, [Bind("Id, Title,Director,ReleaseYear,Price")] Movie movie)
        {
            //Checks the shopping cart received from session, 
            // you initialize the list otherwise it returns
            //  if it is null,the list from the session
            
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart")?? new List<int> { }; 
            cartList.Add(movieId); //add the movieId to the list
            _cartService.AddMovieToCart(movie.Id);
            var numberOfListItems = cartList.Count(); //counts and adds the count to numberoflistitems
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList); //reset the shopping list and store in session                
            return Json(numberOfListItems);
        }

        public IActionResult DisplayCart()
        {
            var moviecartItems = _cartService.DisplayCart();
            return View(moviecartItems);
        }
        
        //[HttpGet]
        //public IActionResult AddItem(int movieid)
        //{
        //    return View();
        //}
        
        //[HttpPost, ActionName("AddItem")]
       public IActionResult AddItem(int movieid)
      // public IActionResult AddCopies(int movieid)
        {
            _cartService.IncreaseCopy(movieid);
           // var movieCartItems = _cartServices.DisplayCart();
            return RedirectToAction("DisplayCart");
        }
        //[HttpGet]
        //public IActionResult ReduceItem(int movieid)
        //{
        //    return View();
        //}

        //[HttpPost, ActionName("ReduceItem")]
        public IActionResult ReduceItem(int movieid)
        {
            _cartService.DecreaseCopy(movieid);
            return RedirectToAction("DisplayCart");
        }
    }
}
