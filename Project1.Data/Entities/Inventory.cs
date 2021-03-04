using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Library
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int OnHand { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
