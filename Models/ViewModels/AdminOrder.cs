using MovieShop.Models.Db;

namespace MovieShop.Models.ViewModels
{
    public class AdminOrder
    {
        public string MovieTitle { get; set; } = string.Empty;

        public string DateOfPurchase { get; set; } = string.Empty ;

        public Movie? movie { get; set; } 

        public List<Order> OrderList { get; set; } = new List<Order>();

    }
}
