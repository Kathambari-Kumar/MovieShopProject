using Microsoft.AspNetCore.Http;
using MovieShop.Models.Db;
using MovieShop.Data;
using MovieShop.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MovieShop.Services
{
    public class CartService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly interstellardb _interstellardb;
        List<CartItem> CartItems = new List<CartItem>();
        public CartService(IHttpContextAccessor httpContextAccessor, interstellardb interstellardb)
        {
            _httpContextAccessor = httpContextAccessor;
            _interstellardb = interstellardb;
        }
    
        //public void AddMovieToCart(Movie movie, int copy)
        public void AddMovieToCart(int movieid)
        {
            var movie = _interstellardb.Movies.SingleOrDefault(m => m.Id == movieid);
            CartItem item = new CartItem();
            item.Title = movie.Title;
            item.TargetURL = movie.TargetUrl;
            item.MovieId = movie.Id;
            item.Price = movie.Price;
            item.Copies = 1;
            if ( _httpContextAccessor.HttpContext.Session.GetString("MovieCart") == null)
            {
                 CartItems.Add(item);
                _httpContextAccessor.HttpContext.Session.SetString("MovieCart", JsonConvert.SerializeObject(CartItems));
            }
            else
            {
                var session = _httpContextAccessor.HttpContext.Session;
                List<CartItem> cartItems = JsonConvert.DeserializeObject<List<CartItem>>(session.GetString("MovieCart"));
                cartItems.Add(item);
                _httpContextAccessor.HttpContext.Session.SetString("MovieCart", JsonConvert.SerializeObject(cartItems));
            }
        }

        public List<CartItem>? DisplayCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            //if (_httpContextAccessor.HttpContext.Session.GetString("MovieCart") != null)
            //{
                List<CartItem>? cartitems = JsonConvert.DeserializeObject<List<CartItem>>(session.GetString("MovieCart"));
                return cartitems;
           // }
            
        }
    }
}
