using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieShop.Data;
using MovieShop.Models.Db;
using Microsoft.EntityFrameworkCore;

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
            
            var customer = _db.Customers.FirstOrDefault(c => c.EmaillAddress == email);


            return customer;

        }

        //update customer

        public void UpdateCustomer(Customer customer) 
        {
            _db.Update(customer);
            _db.SaveChanges();


        }








    }
}
