using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.ViewModel
{
    public class ProfileFormViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "الاسم الاخير")]
        public string LastName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "الايميل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

    }
}
