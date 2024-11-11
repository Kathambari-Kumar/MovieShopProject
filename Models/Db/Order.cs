namespace MovieShop.Models.Db
{
    public class Order
    {

        public int Id { get; set; }
        public string OrderDate { get; set; } = string.Empty;
        public Customer? Customer { get; set; }

        public List<OrderRow> OrderRowList { get; set; } = new List<OrderRow>();


    }
}
