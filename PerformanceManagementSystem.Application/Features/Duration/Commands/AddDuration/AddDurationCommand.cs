using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommand : IRequest<Result<DurationDtoResponse>>
    {
        public string Name { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End{ get; set; }
    }
}
