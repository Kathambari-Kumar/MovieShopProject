using MovieShop.Models.Db;

namespace MovieShop.Models.ViewModels
{
    public class CustomerOrder
    {
        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty ;

        public string CustomerName =>$"{Firstname} {Lastname}";

       
        public int OrderID { get; set; }
        public string DateOfPurchase { get; set; } = string.Empty;


        public List<MovieViewModel>? Movies { get; set; }


        public double TotalOrderCost { get; set; }

        public int TotalOrderCount { get; set; }

       

       
    }
}
