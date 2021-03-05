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

        [HttpPost("api/customer")]
        public void CreateCustomer(BL.Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        [HttpGet("api/customer/{partOfName}")]
        public List<BL.Customer> GetCustomerByName(string partOfName)
        {
            return _customerRepository.GetCustomerByName(partOfName);
        }

        [HttpGet("api/customer/{id}")]
        public BL.Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }
    }
}