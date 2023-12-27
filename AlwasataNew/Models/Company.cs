namespace AlwasataNew.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
