using Project1.BL;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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
            var product = _context.Products.Where(p => p.ProductId == id).First();
            BL.Product searched = new BL.Product(product.ProductId, product.ProductName, product.UnitPrice);
            return searched;
        }
    }
}