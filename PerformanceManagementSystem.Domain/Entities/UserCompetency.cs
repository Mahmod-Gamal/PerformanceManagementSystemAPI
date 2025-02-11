namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserCompetency : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public int CompetenciesID { get; set; }
        public Competency Competency { get; set; }
        public int PerviousLevel { get; set; }
        public int CurrentLevel { get; set; }
        public int StageID { get; set; }
    }
}
