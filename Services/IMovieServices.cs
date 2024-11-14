using MovieShop.Models.Db;

namespace MovieShop.Services
{
    public interface IMovieServices
    {
        public void Create(Movie movie);
        public List<Movie> Display();

        public List<Movie> Top5Newest();
        public List<Movie> Top5Oldest();

        public List<Movie> Top5Cheapest();
        public bool UpdateMoviePrice(Movie updatePrice);
    }
}
