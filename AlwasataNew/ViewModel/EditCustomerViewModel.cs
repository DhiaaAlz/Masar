using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.ViewModel
{
    public class EditCustomerViewModel
    {
        public int Id { get; set; }


        [Display(Name ="الاسم")]
        public string? CustomerName { get; set; }

        [Display(Name = "الهاتف")]
        public string Phone { get; set; }


        [Display(Name ="الايميل")]
        public string? Email { get; set; }

        [Display(Name = "اسم الشركة")]
        public string? CompanyName { get; set; }

        [Display(Name = "اسم الموظف")]
        public string? EmployeeName { get; set; }

        [Display(Name = "المسمى الوظيفي")]
        public string? JobTitle { get; set; }

        [Display(Name = "حالة العميل")]
        public string? CustomerState { get; set; }

        [Display(Name = "موقع الشركة")]
        public string? CompanySite { get; set; }

        [Display(Name = "العنوان")]
        public string? Address { get; set; }


        [Display(Name="نوع العميل")]
        public string? Type { get; set; }

        [Display(Name ="تم انشائه بواسطة")]
        public string? CreatedBy { get; set; }


        [Display(Name ="متابع من قبل")]
        public string? FollowBy { get; set; }

        [Display(Name = "تابع لأي شركة")]
        public int? ForCompany { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "وصف المشروع")]
        public string? ProjectDescription { get; set; }

        [Display(Name = "نوع المشروع")]
        public string? ProjectType { get; set; }

        [Display(Name = "وصف  نوع المشروع")]
        public string? DescriptionProjectType { get; set; }

        [Display(Name = "مساحة المشروع")]
        public double ProjectLandArea { get; set; }

        [Display(Name = "نمط المشروع")]
        public string? ProjectModel { get; set; }
        [Display(Name = "مصدر العميل")]
        public string? ClientSourceDataAndOther { get; set; }

        [Display(Name = "مصدر العميل")]
        public string? ClientSourceEmployee { get; set; }

        [Display(Name = "مصدر العميل")]
        public string? ClientSourceMarkter { get; set; }

        [Display(Name = "العميل قادم من")]
        public string? CustomerComeFrom { get; set; }


    }
}
