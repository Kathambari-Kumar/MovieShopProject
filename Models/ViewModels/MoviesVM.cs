using MovieShop.Models.Db;

namespace MovieShop.Models.ViewModels
{
    public class MoviesVM
    {
        public List<Movie> Top5Newest {  get; set; } = new List<Movie>();

        public List<Movie> Top5Oldet { get; set; } = new List<Movie>();

        public List<Movie> Top5Cheapest { get; set; } = new List<Movie>();

    }
}
