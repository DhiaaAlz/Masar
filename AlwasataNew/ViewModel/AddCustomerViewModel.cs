using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.ViewModel
{
    public class AddCustomerViewModel
    {

        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "الاسم الكامل")]
        public string? CustomerName { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        [EmailAddress]
        [Display(Name = "الايميل")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "الجوال")]
        public string Phone { get; set; }

        [Display(Name = "اسم الشركة")]
        public string? CompnayName { get; set; }

        [Display(Name = "اسم الموظف")]
        public string? EmployeeName { get; set; }

        [Display(Name = "المسمى الوظيفي")]
        public string? JobTitle { get; set; }

        [Display(Name = "العنوان")]
        public string? Address { get; set; }

        [Display(Name = "موقع الشركة")]
        public string? CompanySite { get; set; }

        [Required]
        [Display(Name = "نوع العميل")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "تابع لأي شركة")]
        public int ForCompany { get; set; }

       
        [Display(Name = "ملاحظات عن العميل")]
        public string? CustomerDescription { get; set; }


        [Display(Name = "وصف المشروع")]
        public string? Description { get; set; }


        [Display(Name = "نوع المشروع")]
        public string ProjectType { get; set; }

        [Display(Name = "وصف نوع المشروع")]
        public string? DescriptionType { get; set; }


        [Display(Name = "مساحة المشروع")]
        public double LandAreaByM { get; set; }


        [Display(Name = "نمط المشروع")]
        public string ProjectModel { get; set; }

        [Display(Name = "نمط اخر للمشروع")]
        public string? OtherProjectModel { get; set; }

        [Display(Name = "الموظف المتابع له")]
        public string? FollowByEmployee { get; set; }

        [Display(Name = "مصدر العميل")]
        public string? ClientSourceDataAndOther { get; set; }

        [Display(Name = "مصدر العميل")]
        public string? ClientSourceEmployee { get; set; }

        [Display(Name = "مصدر العميل")]
        public string? ClientSourceMarkter { get; set; }
        [Display(Name = "مصدر العميل")]
        public string? MarktingCampaigns { get; set; }

        [Display(Name = "العميل قادم من")]
        public string? CustomerComeFrom { get; set; }


    }
}
