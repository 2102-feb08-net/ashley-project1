using System;

namespace Project1.WebUI.Models
{
    public class Order
    {
        public int OrderId { get; private set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }
    }
}