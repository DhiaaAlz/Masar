using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class CustomerStateDescriptionTbl
    {
        [Key]
        public int StateId { get; set; }
        public string StateDescription { get; set; }
        public int? FollowTo { get; set; }
    }
}
