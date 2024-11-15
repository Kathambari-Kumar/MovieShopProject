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
                //var ismovie = (CartItem)cartItems[0];
                var ismovie = cartItems.Where(c=>c.MovieId == movieid).FirstOrDefault();
                if (ismovie != null)
                {
                    ismovie.Copies = ismovie.Copies + 1;
                }
                else
                {
                    cartItems.Add(item);
                }
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
        public void IncreaseCopy(int id)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            List<CartItem>? cartitems = JsonConvert.DeserializeObject<List<CartItem>>(session.GetString("MovieCart"));
            var movie = cartitems.Where(m => m.MovieId == id).FirstOrDefault();
            if (movie != null)
            {
                movie.Copies = movie.Copies + 1;
            }
            _httpContextAccessor.HttpContext.Session.SetString("MovieCart", JsonConvert.SerializeObject(cartitems));
        }

        public void DecreaseCopy(int id)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            List<CartItem>? cartitems = JsonConvert.DeserializeObject<List<CartItem>>(session.GetString("MovieCart"));
            var movie = cartitems.Where(m => m.MovieId == id).FirstOrDefault();
            if (movie != null)
            {
                movie.Copies = movie.Copies - 1;
                if (movie.Copies == 0)
                {
                    cartitems.Remove(movie);
                }
            }
            _httpContextAccessor.HttpContext.Session.SetString("MovieCart", JsonConvert.SerializeObject(cartitems));
        }
    }
}
