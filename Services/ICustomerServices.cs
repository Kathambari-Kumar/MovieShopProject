using MovieShop.Models;


namespace MovieShop.Services
{
    public interface ICustomerServices
    {
        public void Create(Customer customer);
        public List<Customer> Display();

    }
}
