using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning
{
    public class SetUserLearningCommand : ICommand<Result<UserLearningDtoResponse>>
    {
        public int Year { get; set; }
        public List<Learning> Learnings { get; set; }
    }
    public class Learning
    {
        public string ImprovementArea { get; set; }
        public string Action { get; set; }
    }

}
