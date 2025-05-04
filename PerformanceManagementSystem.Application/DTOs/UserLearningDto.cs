namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserLearningDto
    {
        public int ID { get; set; }
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? ManagerRating { get; set; }
        public string? ManagerComment { get; set; }
        public List<UserTrainingDto> UserTrainings { get; set; } = new List<UserTrainingDto>();

    }
}
