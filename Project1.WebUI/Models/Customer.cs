using System;

namespace Project1.WebUI.Models
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
    }
}