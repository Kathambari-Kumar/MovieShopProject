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
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly interstellardb _interstellardb;

        public CartController(CartService cartService, interstellardb interstellardb)
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
            var movieCartItems = _cartService.DisplayCart();
            if (movieCartItems.Count > 0)
            {
                return View(movieCartItems);
            }
            else
            {
                return RedirectToAction("EmptyCartMessage");
            }
        }

        public IActionResult EmptyCartMessage()
        {
            return View();
        }

        public IActionResult PlacingOrder()
        {
            return View();
        }

        public IActionResult GettingCartCount()
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            //Display the count of cart
            var numberOfListItems = cartList.Count();
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

            // get the movie from DB and pass it as parameter 
            // AddMovieToCart is a method
            // it adds movie obj, copies of movie
            return Json(numberOfListItems);
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            var email = Request.Form["customerEmail"];
            _cartService.CustomerCheckout(email);
            Console.WriteLine(email);
            return View();
        }

        public IActionResult GettingNewCustomer()
        {
            return View();
        }

   
        [HttpPost]
        public IActionResult CreateNewCustomer()
        {
            Customer customer = new Customer();
            var fname = Request.Form["FirstName"];
            var lname = Request.Form["LastName"];
            var billingaddr = Request.Form["BillingAddr"];
            var billingzip = Request.Form["BillingZip"];
            var billingcity = Request.Form["BillingCity"];
            var deliveryaddr = Request.Form["DeliveryAddr"];
            var deliveryzip = Request.Form["DeliveryZip"];
            var deliverycity = Request.Form["DeliveryCity"];
            var emailaddr = Request.Form["EmailAddr"];
            var phoneno = Request.Form["PhoneNo"];
            customer.Firstname = fname;
            customer.Lastname = lname;
            customer.BillingAddress = billingaddr;
            customer.BillingCity = billingcity;
            customer.BillingZip = Int32.Parse(billingzip);
            customer.DeliveryAddress = deliveryaddr;
            customer.DeliveryCity = deliverycity;
            customer.DeliveryZip = Int32.Parse(deliveryzip);
            customer.EmaillAddress = emailaddr;
            customer.PhoneNo = phoneno;
            _cartService.AddingNewCustomer(customer);
            return RedirectToAction("PlacingOrder");
        }
        public IActionResult AddItem(int movieid)
        {
            _cartService.IncreaseCopy(movieid);
            return View();
        }

        public IActionResult ReduceItem(int movieid)
        {
            _cartService.DecreaseCopy(movieid);
            return View();
        }
    }
}
