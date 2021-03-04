using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BL;


namespace Project1.WebUI.Data
{
    public class CustomerRepository
    {
        private readonly Library.Project1Context _context;
            
        public CustomerRepository(Library.Project1Context context)
        {
            _context = context;
        }

        public bool CreateCustomer(Customer customer)
        {
            Customer customerToCreate = new Customer() 
                { FirstName = customer.FirstName, LastName = customer.LastName, Phone = customer.Phone, 
                    Email = customer.Email, Zip = customer.Zip };
            
            _dbContext.Add(customerToCreate);
            _dbContext.SaveChanges();

            return true;
        }

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