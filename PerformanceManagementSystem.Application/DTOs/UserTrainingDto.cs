namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserTrainingDto
    {
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Review { get; set; }
        public int ManagerReview { get; set; }
    }
}
