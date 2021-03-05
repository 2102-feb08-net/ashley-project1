using Project1.BL;

namespace Project1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Project1Context _context;

        public ProductRepository(Project1Context context)
        {
            _context = context;
        }

        public BL.Product GetProductById(int id)
        {
            var result = _context.Customers.Where(c => c.CustomerId == id).First();
            Library.Models.CustomerModel customer = 
                new Library.Models.CustomerModel(result.FirstName, result.LastName, result.Phone, result.Email, result.Zip, result.CustomerId);
            Console.WriteLine($"\n\nCustomer ID: {customer.CustomerId}\nName: {customer.FirstName} {customer.LastName}\nPhone: {customer.Phone}\nEmail: {customer.Email}\nZip: {customer.Zip}");
            return customer;
        }
    }
}