using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration
{
    public class DeleteDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteDurationCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteDurationCommand request, CancellationToken cancellationToken)
        {
            var duration = await unitOfWork.DurationRepository.GetByIdAsync(request.ID);
            if (duration is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("Duration Not Found");
            await unitOfWork.DurationRepository.UpdateDependenciesToDefaults(request.ID);
            unitOfWork.DurationRepository.Remove(duration);
            return Result<AcknowledgmentDtoResponse>.Ok(new("Deleted Successfully"));
        }
    }
}
