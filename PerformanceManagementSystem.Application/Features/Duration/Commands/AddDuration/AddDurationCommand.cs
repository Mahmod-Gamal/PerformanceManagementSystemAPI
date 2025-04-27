using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommand : ICommand<Result<DurationDtoResponse>>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public DateOnly Start{ get; set; }
        public DateOnly End { get; set; }
    }
}
