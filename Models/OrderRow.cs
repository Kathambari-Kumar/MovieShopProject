namespace MovieShop.Models
{
    public class OrderRow
    {

        public int Id { get; set; }


        public double Price { get; set; }

        public Movie? Movie { get; set; }


        public Order?  Order { get; set; }
    }
}
