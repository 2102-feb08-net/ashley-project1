namespace Project1.BL
{
    public class Store
    {
        public int StoreId { get; private set; }
        public string StoreName { get; set; }

        public Store()
        {   
        }

        public Store(int storeId, string storeName)
        {
            StoreId = storeId;
            StoreName = storeName;
        }
    }
}