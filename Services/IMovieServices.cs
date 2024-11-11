using MovieShop.Models;

namespace MovieShop.Services
{
    public interface IMovieServices
    {
        public void Create(Movie movie);
        public List<Movie> Display();
    }
}
