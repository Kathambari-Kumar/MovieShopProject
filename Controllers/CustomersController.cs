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


        public IActionResult EnterEmail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateCustomer(string email)
        {
           
           var customer = _customerService.GetCustomerByemail(email);
            if (customer == null)
            { 
                return NotFound();
            }


         return View(customer);
        }


        [HttpPost]

        public IActionResult UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid) 
            { 
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Details", new { email = customer.EmaillAddress });
            
            }

            return View(customer);


        }

        public IActionResult Success()
        {
            return View();
        }







    }
}
