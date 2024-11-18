using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Models.Db;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.Net;


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



        public List<Movie> Update()
        {
            var movies = _db.Movies.ToList();
            return movies;
        }








        
        
           
            

       






    }


}
