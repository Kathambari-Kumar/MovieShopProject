using MovieShop.Models.Db;
using MovieShop.Models.ViewModels;

namespace MovieShop.Services
{
    public interface IOrderService
    {

        public List<CustomerOrder> GetCustomerOrders(string email);
    }
}
