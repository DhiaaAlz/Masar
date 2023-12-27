using Microsoft.Extensions.Hosting;

namespace AlwasataNew.Models
{
    //Principle (Parent) 
    public class Customer
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CompanyName { get; set; }
        public string? EmployeeName { get; set; }
        public string? JobTitle { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? CompanySite { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public string? FollowBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CustomerState { get; set; }
        public string? Password { get; set; }
        public int? CompanyId { get; set; }
        public string? CustomerComeFrom { get; set; }
        public string? CustomerDescription { get; set; }
        public string? ClientSource { get; set; }
        public ICollection<Project>? Projects { get; } = new List<Project>();
    }



}
