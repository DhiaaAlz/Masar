using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.ViewModel
{
    public class RoleFormViewModel
    {
        [Required,StringLength(256)]
        public string Name { get; set; }
    }
}
