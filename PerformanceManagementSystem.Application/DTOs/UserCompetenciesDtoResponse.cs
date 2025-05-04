namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserCompetenciesDtoResponse
    {
        public int Year { get; set; }
        public int StageID { get; set; }
        public List<UserCompetencyDto> UserCompetencies { get; set; }

        // public List<UserCompetencyDto> CoreCompetencies { get; set; }
        // public List<UserCompetencyDto> FunctionalCompetencies { get; set; }

    }
}
