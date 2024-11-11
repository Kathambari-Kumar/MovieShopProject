using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieShop.Models.Db;

namespace MovieShop.Data
{
    public class interstellardb : DbContext
    {
        public interstellardb(DbContextOptions dbContextoptions) : base(dbContextoptions) { }

        public DbSet<Customer>Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderRow> OrderRows { get; set; }




    }
}
