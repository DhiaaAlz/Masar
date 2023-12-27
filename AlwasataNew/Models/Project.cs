namespace AlwasataNew.Models
{
    //Dependent (child)
    public class Project
    {
        
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? DescriptionType { get; set; }
        public double LandAreaByM { get; set; }
        public string? Model { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDone { get; set; }
        public string? WorkType { get; set; }
        public string? InitialDesignStage { get; set; }
        public string? InitialExcuationStage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Customer Customer { get; set; }
    }

}
