using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;


namespace MovieShop.Services
{
    public interface ICustomerServices
    {
        public void Create(Customer customer);
        public List<Customer> Display();

        public Customer GetCustomerByemail(string email);

        public void UpdateCustomer(Customer customer);

        public List<CustomerOrder> GetCustomerOrders(string email);





    }
}
