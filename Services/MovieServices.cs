using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using MovieShop.Data;
using MovieShop.Models.Db;

namespace MovieShop.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly interstellardb _db;

        public MovieServices(interstellardb db) 
        { 
            _db = db;
        }
        public void Create(Movie movie) 
        {
            try
            {
                if (movie != null)
                {
                    _db.Movies.Add(movie);
                    _db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Field Values should not be null!");
            }
        }
        public List<Movie> Display()
        {
            var movies = _db.Movies.ToList();
            return movies;
        }

        public List<Movie> Top5Newest()
        {
            var top5newest = _db.Movies
                              .OrderByDescending(x => x.Release_Year)
                             .Take(5).ToList();


            return top5newest;
        }
        public List<Movie> Top5Oldest()
        {
            var top5Oldest = _db.Movies
                              .OrderBy (x => x.Release_Year)
                              .Take(5).ToList();

            return top5Oldest;

        }
        public List<Movie> Top5Cheapest()
        {
            var top5Cheapest = _db.Movies
                               .OrderBy(x => x.Price)
                               .Take(5).ToList();

            return top5Cheapest;

        }
        public bool UpdateMoviePrice(Movie updatePrice)
        {
           var movie = _db.Movies.Find(updatePrice.Id);
            if (movie == null)
            {
                return false;
            }
            movie.Price = updatePrice.Price;
            _db.SaveChanges();
            return true;
        }
    }
}
