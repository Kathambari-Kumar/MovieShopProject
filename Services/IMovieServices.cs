using Microsoft.AspNetCore.Mvc;
using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;

namespace MovieShop.Services
{
    public interface IMovieServices
    {
        public void Create(Movie movie);
        public List<Movie> Display();

        public List<Movie> Top5Newest();
        public List<Movie> Top5Oldest();

        public List<Movie> Top5Cheapest();


        public List<Movie> Update(Movie movie);

        

        public List<Movie> MoviesListGenre(string genre);

        public Movie GetMovieById(int id);

        public void Editmovie(Movie movie);

        public List<AdminOrder> GetAllOrders();

    }
}
