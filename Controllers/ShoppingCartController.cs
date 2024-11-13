using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Extensions;
using Newtonsoft.Json;

namespace MovieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddToCart(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart")?? new List<int> { }; //Checks the shopping cart received from session, if it is null, you initialize the list otherwise it returns the list from the session
            cartList.Add(movieId); //add the movieId to the list
            var numberOfListItems = cartList.Count(); //counts and adds the count to numberoflistitems
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList); //reset the shopping list and store in session
            return Json(numberOfListItems);
           
        }

    }
}
