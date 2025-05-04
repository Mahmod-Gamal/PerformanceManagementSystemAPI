namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserTraining : BaseEntity
    {
        public int UserLearningID { get; set; }
        public UserLearning UserLearning { get; set; }
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? ManagerRating { get; set; }
        public string? ManagerComment { get; set; }
    }
}
