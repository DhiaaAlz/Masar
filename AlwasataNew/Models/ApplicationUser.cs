using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public int? CompanyId { get; set; }
    }
}
