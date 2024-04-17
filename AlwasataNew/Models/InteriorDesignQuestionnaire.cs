using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class InteriorDesignQuestionnaire
    {
        [Display(Name = "رقم الاستبيان")]
        public int Id { get; set; }

        [Display(Name = "اسم العميل")]
        public string ClientName { get; set; }

        [Display(Name = "رقم الجوال")]
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

        public int GroundFloorQuestionnaireId { get; set; }

        public int FirstFloorQuestionnaireId { get; set; }

        public int InterfacesId { get; set; }
    }
}
