using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Services;
using System;

namespace MovieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<interstellardb>(o =>
               o.UseSqlServer(connectionString));
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<IMovieServices, MovieServices>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
