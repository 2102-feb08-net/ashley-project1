using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BL;
using Project1.Data;

namespace Project1.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Project1Context _context;
        public BL.Store GetStoreById(int id)
        {
            var result = _context.Stores.Where(c => c.StoreId == id).First();
            BL.Store store = 
                new BL.Store(result.StoreId, result.StoreName);
            Console.WriteLine($"\n\nStore ID: {store.StoreId}\nName: {store.StoreName}");
            return store;
        }
    }
}