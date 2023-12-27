namespace AlwasataNew.Models
{
    public class CustomerStateDescription
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EmployeeId { get; set; }
    }
}
