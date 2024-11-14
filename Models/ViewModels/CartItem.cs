
namespace MovieShop.Models.ViewModels
{
    public class CartItem
    {
        public int MovieId { get; set; }
        public string TargetURL { get; set; }  = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Copies {  get; set; }
    }
}
