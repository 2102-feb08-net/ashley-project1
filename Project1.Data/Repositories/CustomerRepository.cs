using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BL;


namespace Project1.WebUI.Data
{
    public class CustomerRepository : BL.ICusotomerRepository
    {
        private readonly Data.Project1Context _context;
            
        public CustomerRepository(Data.Project1Context context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            Customer customerToCreate = new Customer() 
                { FirstName = customer.FirstName, LastName = customer.LastName, Phone = customer.Phone, 
                    Email = customer.Email, Zip = customer.Zip };
            
            _dbContext.Add(customerToCreate);
            _dbContext.SaveChanges();
        }

        public List<BL.Customer> GetCustomerByName(string partOfName)
        {
            List<BL.Customer> list = new List<BL.Customer>();
            var results = _dbContext.BL.Customer.Where(c => c.FirstName.ToLower().Contains(partOfName) || c.LastName.ToLower().Contains(partOfName));

            foreach (var result in results)
            {
                list.Add(new BL.Customer(result.FirstName, result.LastName, result.Phone, result.Email, result.Zip, result.CustomerId));
                Console.WriteLine($"{result.CustomerId}\t{result.FirstName} {result.LastName}\t{result.Phone}\t{result.Email}\t{result.Zip}");
            }
            return list;
        }

        public BL.Customer GetCustomerById(int id) 
        {
            var result = _dbContext.Customers.Where(c => c.CustomerId == id).First();
            BL.Customer customer = 
                new BL.Customer(result.FirstName, result.LastName, result.Phone, result.Email, result.Zip, result.CustomerId);
            Console.WriteLine($"\n\nCustomer ID: {customer.CustomerId}\nName: {customer.FirstName} {customer.LastName}\nPhone: {customer.Phone}\nEmail: {customer.Email}\nZip: {customer.Zip}");
            return customer;
        }
    }
}