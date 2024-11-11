using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieShop.Models.Db;

namespace MovieShop.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions dbContextoptions) : base(dbContextoptions) { }

        public DbSet<Customer>Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderRow> OrderRows { get; set; }




    }
}
