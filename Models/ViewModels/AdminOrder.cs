using MovieShop.Models.Db;

namespace MovieShop.Models.ViewModels
{
    public class AdminOrder 
    {
        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string CustomerName => $"{Firstname} {Lastname}";

        public string DateOfPurchase { get; set; } = string.Empty ;

        public int OrderId { get; set; }

        public double TotalOrderCost { get; set; }

        public int TotalOrderCount { get; set; }


        public List<MovieViewModel>? Movies { get; set; } 

    }
}
