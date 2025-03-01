﻿namespace  PerformanceManagementSystem.Domain.Entities
{
    public class UserTraining : BaseEntity
    {
        public int UserGoalID { get; set; }
        public UserGoal UserGoal { get; set; }
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
