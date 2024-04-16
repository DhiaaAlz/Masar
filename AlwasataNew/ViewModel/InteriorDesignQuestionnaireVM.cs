using AlwasataNew.Models;
using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.ViewModel
{
    public class InteriorDesignQuestionnaireVM
    {
        public int Id { get; set; }

        [Display(Name ="اسم العميل")]
        public string ClientName { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نوع المشروع")]
        public string ProjectType { get; set; }

        [Display(Name = "طراز التصميم")]
        public string DesignStyle { get; set; }

        [Display(Name = "مساحة المبنى")]
        public string BuldingArea { get; set; }

        [Display(Name = "دور السطح")]
        public string SurfaceFloor { get; set; }

        [Display(Name = "البدروم")]
        public string Basment { get; set; }

        public GroundFloorQuestionnaire GroundFloorQuestionnaire { get; set; }
        public FirstFloorQuestionnaire FirstFloorQuestionnaire { get; set; }
        public Interfaces Interfaces { get; set; }

    }
}
