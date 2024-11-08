using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Movie
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required")]
            [StringLength(150, ErrorMessage = "Max Length is 150")]
            public string Title { get; set; } = string.Empty;

            [Required]
            [StringLength(100, ErrorMessage = "Max Length is 100")]
            public string Director { get; set; } = string.Empty;
            [Required]
            [StringLength(100, ErrorMessage = "Max Length is 100")]
            public string Genre { get; set; } = string.Empty;
            public int Release_Year { get; set; }
            public double Price { get; set; }
    }
}
