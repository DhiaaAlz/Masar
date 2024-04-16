using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class Interfaces
    {
        public int Id { get; set; }

        [Display(Name = "الواجهات الامامية")]
        public bool FrontInterfaces { get; set; }

        [Display(Name = "الواجهات الجانبية")]
        public bool SideInterfaces { get; set; }

        [Display(Name = "الواجهات الجانبية 2")]
        public bool SideInterfaces2 { get; set; }

        [Display(Name = "الواجهات الخلفية")]
        public bool BackInterfaces { get; set; }

        public int InteriorDesignQuestionnaireId { get; set; }


    }
}
