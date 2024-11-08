namespace MovieShop.Models
{
    public class Order
    {

        public int Id { get; set; }


        public string OrderDate { get; set; } = string.Empty;


        public  Customer? Customer  { get; set; }
    }
}
