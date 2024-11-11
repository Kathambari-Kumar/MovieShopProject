using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models.Db
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string Firstname { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string Lastname { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string BillingAddress { get; set; } = string.Empty;

        public int BillingZip { get; set; }

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string BillingCity { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string DeliveryAddress { get; set; } = string.Empty;

        public int DeliveryZip { get; set; }

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string DeliveryCity { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Maxlength is 50.")]
        public string EmaillAddress { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Maxlength is 20.")]
        public string PhoneNo { get; set; } = string.Empty;

        public List<Order> OrderList { get; set; } = new List<Order>();

    }
}
