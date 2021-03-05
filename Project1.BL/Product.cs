namespace Project1.BL
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public Product()
        {   
        }

        public Product(int productId, string productName, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
        }
    }
}