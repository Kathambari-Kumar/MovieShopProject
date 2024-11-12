﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieShop.Data;
using MovieShop.Models.Db;

namespace MovieShop.Services
{
    public class CustomerServices : ICustomerServices
    {

        private readonly interstellardb _db;


        public CustomerServices(interstellardb db)
        {
            _db = db;
            
        }
        public void Create(Customer customer) 
        {
            try
            {
                if (customer != null)
                {
                    _db.Add(customer);
                    _db.SaveChanges();
                }

            }
            catch 
            {
                Console.WriteLine("Field Values should not be null!");


            }
            
        }
        public List<Customer> Display()
        {
            var customerList = _db.Customers.ToList();


            return customerList;
        }
    }
}
