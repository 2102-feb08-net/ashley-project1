using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BL;
using Project1.Data;


namespace Project1.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Data.Project1Context _context;
            
        public CustomerRepository(Project1Context context)
        {
            _context = context;
        }

        public void CreateCustomer(BL.Customer customer)
        {
            Customer customerToCreate = new Customer() 
                { FirstName = customer.FirstName, LastName = customer.LastName, Phone = customer.Phone, 
                    Email = customer.Email, Zip = customer.Zip };
            
            _context.Add(customerToCreate);
            _context.SaveChanges();
        }

        public List<BL.Customer> GetCustomerByName(string partOfName)
        {
            List<BL.Customer> list = new List<BL.Customer>();
            var results = _context.Customers.Where(c => c.FirstName.ToLower().Contains(partOfName) || c.LastName.ToLower().Contains(partOfName));

            foreach (var result in results)
            {
                list.Add(new BL.Customer(result.CustomerId, result.FirstName, result.LastName, result.Phone, result.Email, result.Zip));
                Console.WriteLine($"{result.CustomerId}\t{result.FirstName} {result.LastName}\t{result.Phone}\t{result.Email}\t{result.Zip}");
            }
            return list;
        }

        public BL.Customer GetCustomerById(int id) 
        {
            var result = _context.Customers.Where(c => c.CustomerId == id).First();
            BL.Customer customer = 
                new BL.Customer(result.CustomerId, result.FirstName, result.LastName, result.Phone, result.Email, result.Zip);
            Console.WriteLine($"\n\nCustomer ID: {customer.CustomerId}\nName: {customer.FirstName} {customer.LastName}\nPhone: {customer.Phone}\nEmail: {customer.Email}\nZip: {customer.Zip}");
            return customer;
        }
    }
}