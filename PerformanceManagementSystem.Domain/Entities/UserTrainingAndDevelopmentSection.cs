namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserTrainingAndDevelopmentSection : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public int StageID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
