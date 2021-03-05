using System.Collections.Generic;

namespace Project1.BL
{
    public interface IProductRepository
    {
        BL.Product GetProductById(int id);
    }
}