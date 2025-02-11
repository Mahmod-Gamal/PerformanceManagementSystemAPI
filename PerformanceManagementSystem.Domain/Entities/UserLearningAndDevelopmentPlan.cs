namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserLearningAndDevelopmentPlan : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public int StageID { get; set; }
    }
}
