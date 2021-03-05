namespace Project1.BL
{
    public class Store
    {
        public int StoreId { get; private set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public Product()
        {   
        }

        public Product(int productId, string productName, decimal unitPrice)
        {
            ProductId = customerId;
            ProductName = firstName;
            UnitPrice = lastName;
        }
    }
}