namespace Project1.BL
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public Customer()
        {   
        }

        public Customer(int customerId, string firstName, string lastName, string phone, string email, string zip)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Zip = zip;
        }

        public Customer(string firstName, string lastName, string phone, string email, string zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Zip = zip;
        }
    }
}