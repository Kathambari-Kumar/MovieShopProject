using Microsoft.AspNetCore.Mvc;
using MovieShop.Services;
using MovieShop.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace MovieShop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServices _customerService;
        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer) 
        {
            _customerService.Create(customer);
            return RedirectToAction("Details");
        }
        public IActionResult Details() 
        {
            var customerlist = _customerService.Display();
            return View(customerlist); 
        }
    }
}
