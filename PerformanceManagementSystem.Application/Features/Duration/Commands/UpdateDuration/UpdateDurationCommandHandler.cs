using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration
{
    public class UpdateDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateDurationCommand, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(UpdateDurationCommand request, CancellationToken cancellationToken)
        {
            var duration = await unitOfWork.DurationRepository.GetByIdAsync(request.ID);
            if (duration is null)
                return Result<DurationDtoResponse>.NotFound("Duration Not found");
            request.Adapt(duration);
            return Result<DurationDtoResponse>.Ok(duration.Adapt<DurationDtoResponse>());
        }
    }
}
