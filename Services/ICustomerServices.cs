using MovieShop.Models.Db;


namespace MovieShop.Services
{
    public interface ICustomerServices
    {
        public void Create(Customer customer);
        public List<Customer> Display();

        public Customer GetCustomerById(int id);


        public void Update(Customer customer);

    }
}
