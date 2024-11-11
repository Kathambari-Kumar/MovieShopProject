using Microsoft.EntityFrameworkCore;
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
    }
}
