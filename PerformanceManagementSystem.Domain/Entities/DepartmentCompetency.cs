namespace  PerformanceManagementSystem.Domain.Entities
{
    public class DepartmentCompetency : BaseEntity
    {
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int CompetenciesID { get; set; }
        public Competency Competency { get; set; }
    }
}
