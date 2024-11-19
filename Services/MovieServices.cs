using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MovieShop.Data;
using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;
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



        public List<Movie> Update(Movie movie)
        {
            var movies = _db.Movies.ToList();
            return movies;
        }

        public List<Movie> MoviesListGenre(string genre)
        {
            var movies = _db.Movies.Where(m => m.Genre == genre).ToList();
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            return movie;
        }
        public void Editmovie(Movie movie)
        {
            try
            {
                if (movie != null)
                {
                    _db.Movies.Update(movie);
                    _db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Field Values should not be null!");
            }
        }

        //public List<Order> GetAllOrders()
        //{
        //    var orderList = _db.OrderRows
        //                   .Join(
        //                          _db.Movies,
        //                          m => m.Id,
        //                           o => o.Id,
        //                      (o, m) => new Order()
        //                      {
        //                          Id = m.Id,
        //                          OrderRowList = m.OrderRowList,
        //                          OrderDate = m.Title,


        //                      })
        //                   .ToList();


        //    return orderList;

        //}

        public List<AdminOrder> GetAllOrders()
        {

            var ordersList = _db.Orders
                                    .Include(o => o.Customer)
                                    .Include(o => o.OrderRowList)
                                    .ThenInclude(or => or.Movie)
                                    .Select(o => new AdminOrder
                                    {
                                        Firstname = o.Customer.Firstname,
                                        Lastname = o.Customer.Lastname,
                                        DateOfPurchase = o.OrderDate,
                                        OrderId = o.Id,
                                        Movies = o.OrderRowList.Select(or => new MovieViewModel
                                        {
                                            Title = or.Movie.Title,
                                            Price = or.Movie.Price


                                        }).ToList(),
                                        TotalOrderCost = o.OrderRowList.Sum(or => or.Movie.Price),
                                        TotalOrderCount = o.OrderRowList.Count()

                                    }).ToList();


            return ordersList;
        }



    }



    }


