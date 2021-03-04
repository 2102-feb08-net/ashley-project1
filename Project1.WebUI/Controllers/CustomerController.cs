using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BL;

namespace Project1.WebUI.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Project1.BL.ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("api/create-customer")]
        public void CreateCustomer(BL.Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        [HttpGet("api/customer-search")]
        public List<BL.Customer> GetCustomerByName(string partOfName)
        {
            List<BL.Customer> list = new List<BL.Customer>();
            var results = _dbContext.Customers.Where(x => x.FirstName.ToLower().Contains(partOfName) || x.LastName.ToLower().Contains(partOfName));


            foreach (var result in results)
            {
                list.Add(new BL.Customer(result.FirstName, result.LastName, result.Phone, result.Email, result.Zip, result.CustomerId));
                Console.WriteLine($"{result.CustomerId}\t{result.FirstName} {result.LastName}\t{result.Phone}\t{result.Email}\t{result.Zip}");
            }
            return list;
        }
    }
}