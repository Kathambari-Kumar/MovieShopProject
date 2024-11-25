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
            return RedirectToAction("CustCreateSuccessMessage");
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

        [HttpPost]
        public IActionResult UpdateCustomer()
        {
           var email = Request.Form["Email"];
           var customer = _customerService.GetCustomerByemail(email);
            if (customer == null)
            { 
                return RedirectToAction("CustomerNotFound");
            }
           return RedirectToAction("Success");
        }

        //[HttpPost]

        public IActionResult SaveCustomer(Customer customer)
        {
            if (ModelState.IsValid) { 
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Success");
            }
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult CustCreateSuccessMessage()
        {
            return View();
        }
        public IActionResult CustomerMenu()
        {
            return View();
        }
        public IActionResult CustomerEmail()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult CustomerOrders()
        {
            var email = Request.Form["Email"];
            var customerOrder = _customerService.GetCustomerOrders(email);
            if (customerOrder == null)
            {
                return RedirectToAction("CustomerNotFound");
            }
            return View(customerOrder);
        }

        public IActionResult CustomerNotFound()
        {
            return View();
        }
    }
}
