namespace BikeStoresApp.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public Store Store { get; set; }
        public Staff Manager { get; set; }

        public List<Staff> Subordinates { get; set; }
        public List<Order> Orders { get; set; }
    }
}
