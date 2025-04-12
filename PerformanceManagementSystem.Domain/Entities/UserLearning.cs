namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserLearning : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public int Review { get; set; }
        public int ManagerReview { get; set; }
    }
}
