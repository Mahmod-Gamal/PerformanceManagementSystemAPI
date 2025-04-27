namespace PerformanceManagementSystem.Application.DTOs
{
    public class CompetencyDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string BasicLevelDescription { get; set; }  // Level 1 - Basic
        public string ProficientLevelDescription { get; set; }  // Level 2 - Proficient
        public string AdvancedLevelDescription { get; set; }  // Level 3 - Advanced
        public string ExpertLevelDescription { get; set; }  // Level 4 - Expert
        public ForeignDto Type { get; set; }0
        public ForeignDto Status { get; set; }
        public ForeignDto Creator { get; set; }
        public ForeignDto Modifier { get; set; }
    }
}
