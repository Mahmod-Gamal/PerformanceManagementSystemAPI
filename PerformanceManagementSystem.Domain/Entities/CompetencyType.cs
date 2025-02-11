namespace  PerformanceManagementSystem.Domain.Entities
{
    public class CompetencyType :BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Competency> Competencies { get; set; }
    }
}
