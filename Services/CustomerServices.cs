using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieShop.Data;
using MovieShop.Models.Db;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models.ViewModels;

namespace MovieShop.Services
{
    public class CustomerServices : ICustomerServices
    {

        private readonly interstellardb _db;


        public CustomerServices(interstellardb db)
        {
            _db = db;
            
        }
        public void Create(Customer customer) 
        {
            try
            {
                if (customer != null)
                {
                    _db.Add(customer);
                    _db.SaveChanges();
                }

            }
            catch 
            {
                Console.WriteLine("Field Values should not be null!");


            }
            
        }
        public List<Customer> Display()
        {
            var customerList = _db.Customers.ToList();


            return customerList;
        }
        public Customer GetCustomerByemail(string email)
        {
            
            var customer = _db.Customers.SingleOrDefault(c => c.EmaillAddress == email);


            return customer;

        }

        //update customer

        public void UpdateCustomer(Customer customer) 
        {
            _db.Update(customer);
            _db.SaveChanges();


        }


        public List<CustomerOrder> GetCustomerOrders(string email)
        {

            var customerOrders = _db.Orders
                                    .Include(o => o.Customer)
                                    .Include(o => o.OrderRowList)
                                    .ThenInclude(or => or.Movie)
                                    .Where(o => o.Customer.EmaillAddress == email)
                                    .Select(o => new CustomerOrder
                                    {
                                        Firstname = o.Customer.Firstname,
                                        Lastname = o.Customer.Lastname,
                                        DateOfPurchase = o.OrderDate,
                                        OrderID = o.Id,
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
