namespace AlwasataNew.Models
{
    public class RemindCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public  string  EmployeeId { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }
}
