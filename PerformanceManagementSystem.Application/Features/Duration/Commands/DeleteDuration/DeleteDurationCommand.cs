using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration
{
    public class DeleteDurationCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
