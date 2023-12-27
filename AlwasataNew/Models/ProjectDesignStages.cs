using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Models
{
    public class ProjectDesignStages
    {
        public int ProjectId { get; set; }
        public string? InitialThoughts { get; set; }
        public string? ArchitecturalDesigns { get; set; }
        public string? ModifyAndDevelop { get; set; }
        public string? Interfaces { get; set; }
        public string? ElectricityPlans { get; set; }
        public string? MechanicsDiagrams { get; set; }
        public string? ConstructionPlans { get; set; }
        public string? ArchitecturalPlans { get; set; }
        public string? Review { get; set; }
    }
}
