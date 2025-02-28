using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserTrainings
{
    public class SetUserTrainingsCommand : ICommand<Result<UserTrainingsDtoResponse>>
    {
        public int Year { get; set; }
        public List<Trainings> Trainingss { get; set; }
    }
    public class Trainings
    {
        public string TrainingCourse { get; set; }
        public string InstituteOfSource { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

}
