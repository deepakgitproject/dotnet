namespace BikeStoresApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }

        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public Staff Staff { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
