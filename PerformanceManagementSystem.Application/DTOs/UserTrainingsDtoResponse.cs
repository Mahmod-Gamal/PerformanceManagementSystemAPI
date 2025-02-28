namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserTrainingsDtoResponse
    {
        public int Year { get; set; }
        public int StageID { get; set; }
        public List<UserTrainingDto> Trainings { get; set; }
    }
}
