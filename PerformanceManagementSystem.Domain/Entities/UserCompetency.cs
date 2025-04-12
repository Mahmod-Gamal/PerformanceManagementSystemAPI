namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserCompetency : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public int CompetencyID { get; set; }
        public Competency Competency { get; set; }
        public int CurrentLevel { get; set; }
        public int ExpectedLevel { get; set; }
        public int Review { get; set; }
        public int ManagerReview { get; set; }
    }
}
