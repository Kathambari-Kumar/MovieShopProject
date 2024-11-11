using MovieShop.Models.Db;

namespace MovieShop.Services
{
    public interface IMovieServices
    {
        public void Create(Movie movie);
        public List<Movie> Display();
    }
}
