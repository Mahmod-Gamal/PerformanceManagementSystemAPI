namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserCompetency : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public int CompetencyID { get; set; }
        public Competency Competency { get; set; }
        public int PerviousLevel { get; set; }
        public int CurrentLevel { get; set; }
    }
}
