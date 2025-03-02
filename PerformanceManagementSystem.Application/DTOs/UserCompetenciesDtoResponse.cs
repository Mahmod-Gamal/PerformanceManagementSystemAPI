namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserCompetenciesDtoResponse
    {
        public int Year { get; set; }
        public int StageID { get; set; }
        public List<UserCompetencyDto> Competencies { get; set; }
    }
}
