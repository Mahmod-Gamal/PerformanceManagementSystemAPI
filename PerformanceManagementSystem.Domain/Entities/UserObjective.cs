namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserObjective : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Review { get; set; }
        public int ManagerReview { get; set; }
    }
}
