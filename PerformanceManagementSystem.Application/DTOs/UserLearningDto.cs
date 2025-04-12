namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserLearningDto
    {
        public int LearningID { get; set; }
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public int Review { get; set; }
        public int ManagerReview { get; set; }
    }
}
