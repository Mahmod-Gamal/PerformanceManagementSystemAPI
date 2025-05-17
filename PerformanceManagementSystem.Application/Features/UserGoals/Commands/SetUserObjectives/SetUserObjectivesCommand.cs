using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives
{
    public class SetUserObjectivesCommand : ICommand<Result<UserObjectivesDtoResponse>>
    {
        public int Year {  get; set; } 
        public List<Objective> UserObjectives { get; set; }
    }
    public class Objective
    {
        public string Description { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }
        public int Weight { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
