using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class FirstFloorQuestionnaire
    {
        public int Id { get; set; }

        [Display(Name = "غرفة النوم الرئيسية")]
        public bool MasterBedroom { get; set; }

        [Display(Name = "غرفة 1")]
        public bool Room1 { get; set; }

        [Display(Name = "صالة الدور الاول")]
        public bool FirstFloorHall { get; set; }

        [Display(Name = "اخرى")]
        public string Other { get; set; }
        public int InteriorDesignQuestionnaireId { get; set; }

    }
}
