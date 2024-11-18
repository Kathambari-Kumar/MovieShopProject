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
            var customer = _db.Customers
                                 .Include(c => c.OrderList)
                                 .ThenInclude(o => o.OrderRowList)
                                 .ThenInclude(or => or.Movie)
                                 .SingleOrDefault(c => c.EmaillAddress == email);

            if (customer == null) 
            {
                return null;
            
            }

            //map to customer view model

            var customerOrders = customer.OrderList
                .SelectMany(o => o.OrderRowList.Select(or => new CustomerOrder
                {
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    MovieTitle = or.Movie.Title,
                    TotalOrderCount = customer.OrderList.Count(),
                    Price = or.Movie.Price,
                    DateOfPurchase = or.Order.OrderDate
                  

                }
                )).ToList();
            
            return customerOrders;
        }


       
    }
}
