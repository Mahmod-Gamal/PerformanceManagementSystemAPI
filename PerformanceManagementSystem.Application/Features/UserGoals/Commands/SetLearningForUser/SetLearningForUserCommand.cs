using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetLearningForUser
{
    public class SetLearningForUserCommand : ICommand<Result<UserLearningDtoResponse>>
    {
        public int Year { get; set; }
        public int UserID { get; set; }
        public List<Learning> Learnings { get; set; }
    }
    public class Learning
    {
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
        public List<Trainings> UserTrainings { get; set; }
    }

    public class Trainings
    {
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public int CourseHour { get; set; }
        public string CourseCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

}
