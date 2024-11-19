namespace MovieShop.Models.ViewModels
{
    public class TopCustomer
    {
        public int Orderid { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
