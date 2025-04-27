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
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? ManagerRating { get; set; }
        public string? ManagerComment { get; set; }
    }
}
