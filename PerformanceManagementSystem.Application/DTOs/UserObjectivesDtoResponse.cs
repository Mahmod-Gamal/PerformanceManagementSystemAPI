namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserObjectivesDtoResponse
    {
        public int Year { get; set; }
        public int StageID { get; set; }
        public List<UserObjectiveDto> Objectives { get; set; }
    }
}
