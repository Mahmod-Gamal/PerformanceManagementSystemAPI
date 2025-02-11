namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserObjective : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public string Objectives { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int StageID { get; set; }
    }
}
