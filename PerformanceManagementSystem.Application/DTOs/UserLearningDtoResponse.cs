namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserLearningDtoResponse
    {
        public int Year { get; set; }
        public int StageID { get; set; }
        public List<UserLearningDto> UserLearning{ get; set; }
    }
}
