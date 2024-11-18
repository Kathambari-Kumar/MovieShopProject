using Microsoft.AspNetCore.Mvc;
using MovieShop.Services;
using MovieShop.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace MovieShop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServices _customerService;
        private readonly IOrderService _orderService;

        public CustomersController(ICustomerServices customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
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


        [HttpPost]
        public IActionResult UpdateCustomer()
        {
         
           var email = Request.Form["Email"];
           var customer = _customerService.GetCustomerByemail(email);
            if (customer == null)
            { 
                return NotFound();
            }


         return View(customer);
        }


        //[HttpPost]

        public IActionResult SaveCustomer(Customer customer)
        {

            if (ModelState.IsValid) { 
                _customerService.UpdateCustomer(customer);


                return RedirectToAction("Success");

            }

            return View(customer);


        }

        public IActionResult Success()
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
            var customerOrder = _orderService.GetCustomerOrders(email);
            return View(customerOrder);
        }




    }
}
