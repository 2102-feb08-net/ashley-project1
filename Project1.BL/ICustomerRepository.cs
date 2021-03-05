using System.Collections.Generic;
namespace Project1.BL
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);

        List<BL.Customer> GetCustomerByName(string partOfName);

        BL.Customer GetCustomerById(int id);
    }
}