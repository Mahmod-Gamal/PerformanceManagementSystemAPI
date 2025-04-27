using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration
{
    public class UpdateDurationCommand : ICommand<Result<DurationDtoResponse>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }

    }
}
