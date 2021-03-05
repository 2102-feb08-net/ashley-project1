using System;

namespace Project1.WebUI.Models
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}