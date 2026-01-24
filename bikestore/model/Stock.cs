namespace BikeStoresApp.Models
{
    public class Stock
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Store Store { get; set; }
        public Product Product { get; set; }
    }
}
