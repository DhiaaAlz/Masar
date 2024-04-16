using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class GroundFloorQuestionnaire
    {
        public int Id { get; set; }

        [Display(Name = "مجلس رجال")]
        public bool MenCouncil { get; set; }

        [Display(Name = "حمام مجلس رجال")]
        public bool WCMenCouncil { get; set; }

        [Display(Name = "مجلس نساء")]
        public bool WomenCouncil { get; set; }

        [Display(Name = "حمام مجلس نساء")]
        public bool WCWomenCouncil { get; set; }

        [Display(Name = "صالة الدور الارضي")]
        public bool GroundFloorHall { get; set; }

        [Display(Name = "المطبخ")]
        public bool Kitchen { get; set; }

        [Display(Name = "الملحق الخارجي")]
        public bool ExternalAttachment { get; set; }

        [Display(Name = "اخرى")]
        public string Other { get; set; }

        public int InteriorDesignQuestionnaireId { get; set; }

    }
}
