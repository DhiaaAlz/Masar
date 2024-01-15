namespace AlwasataNew.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
        public string FollowBy { get; set; }
        public string CustomerState { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerComeFrom { get; set; }
        public string ClientSource { get; set; }
        public IEnumerable<int> ProjectsId { set; get; }

    }
}
