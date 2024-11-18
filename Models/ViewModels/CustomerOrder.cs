using MovieShop.Models.Db;

namespace MovieShop.Models.ViewModels
{
    public class CustomerOrder
    {
        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty ;

        public string CustomerName =>$"{Firstname} {Lastname}";

        public string MovieTitle { get; set; } = string.Empty;

        public string DateOfPurchase { get; set; } = string.Empty;

        public double Price { get; set; } //price of individual movie

       

        public int TotalOrderCount { get; set; }

       

       
    }
}
