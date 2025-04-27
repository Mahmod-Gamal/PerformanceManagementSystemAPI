namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserLearning : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? ManagerRating { get; set; }
        public string? ManagerComment { get; set; }
    }
}
