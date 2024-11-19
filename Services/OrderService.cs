using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;

namespace MovieShop.Services
{
    public class OrderService:IOrderService
    {


        private readonly interstellardb _db;


        public OrderService(interstellardb db)
        {
            _db = db;
            
        }

        public List<CustomerOrder> GetCustomerOrders(string email) 
        {

            var customerOrders = _db.Orders
                                    .Include(o => o.Customer)
                                    .Include(o => o.OrderRowList)
                                    .ThenInclude(or => or.Movie)
                                    .Where(o => o.Customer.EmaillAddress == email)
                                    .Select( o => new CustomerOrder
                                    {
                                        Firstname = o.Customer.Firstname,
                                        Lastname = o.Customer.Lastname,
                                        DateOfPurchase = o.OrderDate,
                                        Movies = o.OrderRowList.Select(or => new MovieViewModel
                                        {
                                            Title = or.Movie.Title,
                                            Price = or.Movie.Price


                                        }).ToList(),
                                        TotalOrderCost = o.OrderRowList.Sum(or => or.Movie.Price),
                                        TotalOrderCount = o.OrderRowList.Count()

                                    }).ToList();
           
         
            return customerOrders;
        }


       
    }
}
